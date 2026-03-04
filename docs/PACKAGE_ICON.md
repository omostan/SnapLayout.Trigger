# Package Icon

To add a package icon for NuGet:

1. Create a 128x128 PNG image named `icon.png`
2. Place it in the root of the `SnapLayout.Trigger` project directory
3. Update the `.csproj` file to include:

```xml
<PropertyGroup>
  <PackageIcon>icon.png</PackageIcon>
</PropertyGroup>

<ItemGroup>
  <None Include="icon.png" Pack="true" PackagePath="\" />
</ItemGroup>
```

The icon should visually represent the Snap Layout functionality (e.g., window grid, snap zones).

For now, the package will use NuGet's default icon until a custom icon is created.
