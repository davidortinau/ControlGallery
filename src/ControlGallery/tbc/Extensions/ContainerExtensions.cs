using DryIoc;
using IContainer = DryIoc.IContainer;

namespace ControlGallery.Extensions;

public static class ContainerExtensions
{
    // called at startup and by reload manager to update container types
    public static IContainer RegisterApplicationTypes(this IContainer container, params Type[] types)
    {
        foreach (var t in types.Where(t => !t.IsAbstract))
        {
            // register pages and viewmodels for direct resolution
            if (t.IsSubclassOf(typeof(Page)))
            {
                container.Register(t, reuse: Reuse.Transient);

                // if you were using shell or prism you could add/overwrite the route registration here
            }

            // register services against interfaces
            // use 'IfAlreadyRegistered.Replace' to replace existing registrations
            // if (t.IsSubclassOf(typeof(BaseService)))
            // {
            //     container.RegisterMany(
            //         new [] { t },
            //         serviceTypeCondition: _ => true,
            //         ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            // }
        }

        return container;
    }
}