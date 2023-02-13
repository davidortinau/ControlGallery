using System.Diagnostics;
using ControlGallery.Extensions;
using DryIoc;
using Tbc.Core.Models;
using Tbc.Target;
using Tbc.Target.Interfaces;
using Tbc.Target.Requests;
using IContainer = DryIoc.IContainer;

namespace ControlGallery;

public class ReloadManager : ReloadManagerBase
{
    private readonly IContainer _container;
    public IReloadManager? Delegate { get; set; }

    public ReloadManager(IContainer container)
    {
        _container = container;
    }

    public override async Task<Outcome> ProcessNewAssembly(ProcessNewAssemblyRequest req)
    {
        var types = req.Assembly.GetTypes();

        // if we're a replaced reloadmanager, pass the request to the replacement
        if (await ForwardToReplacement(req) is { } forwardedOutcome)
            return forwardedOutcome;

        // register any new reloaded types so we can resolve them with dependencies
        RegisterUpdatedTypes(types);

        // try to find a page to present and present it
        if (await PresentPageIfReloaded(types, req.PrimaryType) is { } presentationOutcome)
            return presentationOutcome;

        return new() { Success = true, Messages = { new() { Message = "No suitable type was found to present" } }};
    }

    private void RegisterUpdatedTypes(Type[] types)
        => _container.RegisterApplicationTypes(types);

    private async Task<Outcome?> PresentPageIfReloaded(Type[] allTypes, Type? primaryType)
    {
        // find a page to present
        // if the 'primary type' (hinted using cli) is a page, it's that, otherwise pick the first page we reloaded
        var maybeFocusPageType =
            primaryType?.IsSubclassOf(typeof(Page)) ?? false
                ? primaryType
                : allTypes.FirstOrDefault(x => x.IsSubclassOf(typeof(Page)));

        if (maybeFocusPageType is not { } focusPageType)
            return null; // nothing to present, let the caller decide the outcome

        // resolve the page from container
        // before calling this we registered it and any changed dependencies
        var page = (Page)_container.Resolve(focusPageType);

        // try to put it on the screen
        var outcome = await MainThread.InvokeOnMainThreadAsync(() =>
        {
            try
            {
                App.Current.MainPage = page;

                return new Outcome { Success = true };
            }
            catch (Exception ex)
            {
                // write it to the console
                Console.WriteLine(ex);

                // or we could put the error on the screen if we wanted
                // App.Current.MainPage = new ContentPage
                // {
                //     Content = new Label
                //     {
                //         Text = ex.ToString()
                //     }
                // };

                return new Outcome { Success = false };
            }
        });

        return outcome;
    }

    // this lets us update the reload manager at runtime
    private async Task<Outcome?> ForwardToReplacement(ProcessNewAssemblyRequest req)
    {
        var replacement = req.Assembly.GetTypes()
           .FirstOrDefault(x => x.ImplementsServiceType<IReloadManager>() && x != GetType());

        if (replacement != null)
        {
            _container.Register(typeof(IReloadManager), replacement, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            Delegate = _container.Resolve<IReloadManager>();
            NotifyReplacement(Delegate);

            return await Delegate.ProcessNewAssembly(req);
        }
        else
        {
            return null;
        }
    }

    public override Task<Outcome> ExecuteCommand(CommandRequest req)
    {
        if (req.Command == "cool")
        {
            var page = App.Current.MainPage;
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                while (true)
                {
                    page.BackgroundColor = new[]
                        {
                            Colors.Red, Colors.Green, Colors.Yellow
                        }.OrderByDescending(_ => Guid.NewGuid())
                       .First();

                    await Task.Delay(TimeSpan.FromSeconds(.1));
                }
            });
        }

        return Task.FromResult(new Outcome { Success = true });
    }
}

