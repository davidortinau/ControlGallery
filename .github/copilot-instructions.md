````instructions
You are an agent - please keep going until the user’s query is completely resolved, before ending your turn and yielding back to the user. Only terminate your turn when you are sure that the problem is solved.

If you are not sure about file content or codebase structure pertaining to the user’s request, use your tools to read files and gather the relevant information: do NOT guess or make up an answer.

You MUST plan extensively before each function call, and reflect extensively on the outcomes of the previous function calls. DO NOT do this entire process by making function calls only, as this can impair your ability to solve the problem and think insightfully.

When in Agent mode, work directly in the code files.

## About the Project

This application is a .NET MAUI mobile and desktop application.

The solution file is in the /src folder, and the project file is in the /src/ControlGallery folder. When issuing a `dotnet build` command you must include a Target Framework Moniker like `dotnet build -f net10.0-maccatalst`. Use the TFM that VS Code is currently targeting, when using VS Code of course.

Here are some general .NET MAUI tips:

- Use `Border` instead of `Frame`
- Use `Grid` instead of `StackLayout`
- Use `CollectionView` instead of `ListView` for lists of greater than 20 items that should be virtualized
- Use `BindableLayout` with an appropriate layout inside a `ScrollView` for items of 20 or less that don't need to be virtualized
- Use `Background` instead of `BackgroundColor`


This project uses C# and XAML with an MVVM architecture. 

Use the .NET Community Toolkit for MVVM. Here are some helpful tips:

## Commands

- Use `RelayCommand` for commands that do not return a value.

```csharp
[RelayCommand]
Task DoSomethingAsync()
{
    // Your code here
}
```

This produces a `DoSomethingCommand` through code generation that can be used in XAML.

```xml
<Button Command="{Binding DoSomethingCommand}" Text="Do Something" />
```

## XAML global xmlns guidelines
- This project relies on global/implicit XAML namespace mappings declared in `_xmlns.cs`. Do NOT add explicit clr-namespace xmlns declarations in XAML files for project namespaces (for example `xmlns:fonts="clr-namespace:Fonts"` or `xmlns:controls="clr-namespace:ControlGallery.Pages.Controls"`).
- Prefer the global XAML URI and implicit prefixes instead: use `xmlns="http://schemas.microsoft.com/dotnet/maui/global"` (or rely on the project default global xmlns) and `xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"` as needed.
- Rationale: `_xmlns.cs` centralizes XmlnsDefinition and XmlnsPrefix mappings so XAML can reference types and static glyphs using `{x:Static FluentUI.*}` or unprefixed element names without per-file clr-namespace wiring.
- Do not re-add the two explicit lines below anywhere in the repo, they are unnecessary when `_xmlns.cs` is present and cause duplication/confusion:
  - `xmlns="http://schemas.microsoft.com/dotnet/maui/global"`
  - `xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"`
- If a XAML file truly needs an external CLR namespace that is not covered by `_xmlns.cs`, add a one-off `xmlns` mapping for that external assembly only and prefer adding an XmlnsDefinition in `_xmlns.cs` for reuse.

## Generated agent guidance (auto-generated)

When running the "generate instructions" action or making broad repo changes, follow these concise rules and examples so edits are consistent and buildable.

- Quick build/run
  - Always build using the project TFM. Example for Mac Catalyst:
    - `dotnet build -f net10.0-maccatalyst -r maccatalyst-arm64 /path/to/src/ControlGallery/ControlGallery.csproj`
  - When running builds from VS Code tasks or CI, explicitly pass the TFM (`-f`) and runtime (`-r`) as shown above.

- Project layout quick references
  - Solution: `src/ControlGallery/ControlGallery.sln`
  - Project: `src/ControlGallery/ControlGallery.csproj`
  - Global implicit XAML mappings (see next): `src/ControlGallery/_xmlns.cs`
  - Shared styles: `src/ControlGallery/Resources/Styles/AppStyles.xaml`
  - Generated font glyphs: `src/ControlGallery/Resources/Fonts/FluentUI.cs`

- XAML implicit xmlns rules (MANDATORY)
  - This repository centralizes XmlnsDefinition and XmlnsPrefix mappings in `_xmlns.cs`. Do NOT add per-file `clr-namespace` xmlns declarations for project namespaces in XAML.
  - If a XAML file truly needs an external CLR namespace not present in `_xmlns.cs`, add a single file `xmlns` mapping for that external assembly ONLY and prefer adding an `XmlnsDefinition` and `XmlnsPrefix` to `_xmlns.cs` for reuse.
  - How to add a prefix (example): edit `src/ControlGallery/_xmlns.cs` and add the appropriate attributes. Example pattern:

    // add to _xmlns.cs
    [assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "ControlGallery.Pages.Controls")]
    [assembly: XmlnsPrefix("http://schemas.microsoft.com/dotnet/maui/global", "controls")]

  - After updating `_xmlns.cs`, a rebuild is required for XAML tooling to pick up the change.

- Shared templates and styles
  - Put reusable CollectionView templates in `AppStyles.xaml` (group header and item templates). Pages should reference these via `StaticResource` so templates are maintained centrally.
  - Use the implicit prefixes declared in `_xmlns.cs` when referencing these types in XAML (for example `fonts:FluentUI` or `controls:MyControlTemplate`).

- Fonts and glyphs
  - Generated font helper classes (like `FluentUI.cs`) must be `public` so XAML `{x:Static}` references can resolve.
  - Keep font generation/regeneration as part of your asset workflow; when updating generated font files, rebuild so XAML resolves glyphs.

- CollectionView migration pattern (recommended)
  1. For menu-like `TableView` pages: replace with a grouped `CollectionView`.
  2. Add a small `GroupedNavItems` model (an `ObservableCollection<NavItem>` with a `Title`).
  3. Create a per-page ViewModel exposing `ObservableCollection<GroupedNavItems> Groups` and a `NavigateCommand`.
  4. Populate `NavItem.Route` with route strings (avoid `typeof(...)` until all target pages and types are resolvable) to prevent CS0246 compile errors during iterative edits.
  5. Reference central `SharedCollectionViewGroupHeaderTemplate` and `SharedCollectionViewItemTemplate` from `AppStyles.xaml`.

- Form-like TableView conversions
  - For pages that use `EntryCell`, `SwitchCell`, `ViewCell` for forms (for example editors), prefer converting to a `ScrollView` + `StackLayout` (or `BindableLayout`) with a small ViewModel to hold two-way bound values.

- Navigation guidance
  - Use Shell routes (string-based) when populating `NavItem` entries from ViewModels to avoid early type-resolution problems. After a later pass you may standardize to typed navigation if desired.

- Common troubleshooting
  - CS0246 for page types: occurs when a ViewModel references `typeof(SomePage)` but `SomePage` is not yet compiled/visible. Switch to route strings to avoid this when making multi-file edits.
  - XAML type resolution errors: verify `_xmlns.cs` contains the appropriate `XmlnsDefinition`/`XmlnsPrefix` entries and that the generated font helper classes are public.
  - Glyphs not found in XAML `{x:Static ...}`: ensure the generated font helper class is `public static` and the `FontFamily` static property is accessible.

- Misc tips and conventions
  - Prefer `Border` over `Frame` and set `StrokeShape` to a `RoundRectangle` when converting `CornerRadius` usages from Frames.
  - Prefer `Grid` over `StackLayout` for complex layouts and `CollectionView` over `ListView` for larger lists.
  - Use the .NET Community Toolkit MVVM attributes (for example `[RelayCommand]`) for new ViewModels.

- Where to look for remaining TODOs
  - The repo contains a short conversion todo list at the workspace root (tracked by the agent). Start with `EasingEditorPage.xaml` (form-like) and then convert the remaining `TableView` demo pages under `src/ControlGallery/Pages/Controls/TableView/`.

If you want, I can now proceed to convert `EasingEditorPage.xaml` using the guidance above and validate with a build. Otherwise these guidelines should be sufficient for follow-up agent runs.
````

