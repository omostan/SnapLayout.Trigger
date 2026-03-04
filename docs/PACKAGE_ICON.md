# Package Icon Guide

## Creating the Perfect NuGet Package Icon

Your NuGet package icon helps users quickly identify your library. Here's how to create and add one.

## Icon Requirements

### Technical Specifications
- **Format**: PNG (Portable Network Graphics)
- **Size**: 128x128 pixels (minimum and recommended)
- **Maximum file size**: 1 MB
- **Transparency**: Supported and recommended

### Design Guidelines
- ✅ Keep it simple and recognizable at small sizes
- ✅ Use high contrast for visibility
- ✅ Avoid text (except maybe a single letter/number)
- ✅ Consider dark and light theme compatibility
- ✅ Match your brand/project style

## Design Ideas for SnapLayout.Trigger

Since this library enables Windows 11 Snap Layouts, your icon should represent:

### Concept 1: Window with Snap Zones
```
┌─────────┬─────────┐
│         │         │
│    1    │    2    │
│         │         │
├─────────┼─────────┤
│         │         │
│    3    │    4    │
│         │         │
└─────────┴─────────┘
```

### Concept 2: Maximize Button with Grid
- A maximize button (⬜) with snap layout zones overlay
- Blue accent color (Windows 11 style)
- Clean, modern look

### Concept 3: Abstract Snap
- Overlapping window outlines
- Gradient or solid colors
- Minimalist design

## Creating Your Icon

### Option 1: Use Figma (Free, Online)
1. Go to https://figma.com
2. Create a new design (128x128)
3. Design your icon
4. Export as PNG

### Option 2: Use Photoshop/GIMP
1. Create new image (128x128)
2. Design with layers
3. Save as PNG

### Option 3: Use Online Icon Makers
- https://www.flaticon.com (Free icons)
- https://www.canva.com (Design tool)
- https://www.remove.bg (Background removal)

### Option 4: AI Generation
Use AI tools like:
- DALL-E
- Midjourney
- Stable Diffusion

**Prompt example:**
> "A minimalist icon for a Windows 11 snap layout library, showing a window divided into 4 sections with a modern blue gradient, 128x128 pixels, PNG, transparent background"

## Simple Icon Template

Here's a simple design you can create yourself:

### Colors
- **Primary**: `#0078D4` (Windows 11 Blue)
- **Secondary**: `#005A9E` (Darker Blue)
- **Background**: Transparent or `#FFFFFF`

### Layout
```
Background: White or Transparent
Border: 2px #0078D4

┌───────────────────┐
│  ┌─────┬─────┐   │
│  │  1  │  2  │   │ ← Snap zones
│  ├─────┼─────┤   │
│  │  3  │  4  │   │
│  └─────┴─────┘   │
└───────────────────┘
```

## Adding the Icon to Your Project

### Step 1: Save the Icon
Save your icon as `icon.png` in the project directory:
```
SnapLayout.Trigger/
├── icon.png              ← Place here
├── SnapLayoutTrigger.cs
└── SnapLayout.Trigger.csproj
```

### Step 2: Project Configuration (Already Done!)
The `.csproj` file is already configured with:
```xml
<PropertyGroup>
  <PackageIcon>icon.png</PackageIcon>
</PropertyGroup>

<ItemGroup>
  <None Include="icon.png" Pack="true" PackagePath="\" />
</ItemGroup>
```

### Step 3: Verify
Build and pack to verify the icon is included:
```bash
dotnet pack --configuration Release
```

Check the `.nupkg` file (it's a ZIP) to verify `icon.png` is in the root.

## Testing Your Icon

### Local Testing
1. Pack the project: `dotnet pack`
2. Open the `.nupkg` file with a ZIP viewer
3. Verify `icon.png` exists in the root

### Visual Studio Testing
1. Add your package to a local feed
2. Open NuGet Package Manager in VS
3. Verify the icon appears

### NuGet.org Testing
After publishing, your icon will appear:
- In search results
- On the package page
- In Visual Studio Package Manager
- In NuGet Gallery

## Example Icon (ASCII Representation)

If you need a placeholder while designing, here's a simple concept:

```
Background: Transparent
Foreground: #0078D4

     ╔═══════╗
     ║ ┌─┬─┐ ║
     ║ ├─┼─┤ ║
     ║ └─┴─┘ ║
     ╚═══════╝
```

## Quick Start: Using a Free Icon

### From Flaticon.com
1. Search for "window grid" or "layout"
2. Download PNG (128x128)
3. Rename to `icon.png`
4. Place in `SnapLayout.Trigger/` folder
5. Attribution (if required): Add to README.md

### From Icons8.com
1. Search for "snap" or "grid"
2. Download as PNG 128x128
3. Save as `icon.png`
4. Free with attribution

## Best Practices

### DO:
- ✅ Keep it simple
- ✅ Use recognizable symbols
- ✅ Test at small sizes (32x32 view)
- ✅ Use transparency wisely
- ✅ Maintain consistent branding

### DON'T:
- ❌ Use copyrighted images without permission
- ❌ Make it too complex
- ❌ Use text unless absolutely necessary
- ❌ Forget to test on dark backgrounds
- ❌ Exceed 1 MB file size

## Color Palette Suggestions

### Windows 11 Theme
```
Primary:   #0078D4 (Blue)
Secondary: #00BCF2 (Cyan)
Accent:    #7A7A7A (Gray)
```

### Modern & Professional
```
Primary:   #2563EB (Blue)
Secondary: #3B82F6 (Light Blue)
Accent:    #1E40AF (Dark Blue)
```

### Minimalist
```
Primary:   #000000 (Black)
Secondary: #6B7280 (Gray)
Accent:    #FFFFFF (White)
```

## Troubleshooting

### Icon doesn't appear on NuGet
- Verify `icon.png` exists in project folder
- Check `.csproj` configuration
- Rebuild and repack
- Wait 5-10 minutes after publishing

### Icon looks blurry
- Ensure it's exactly 128x128 pixels
- Use PNG format (not JPG)
- Avoid scaling up smaller images

### Icon too large
- Compress using TinyPNG.com
- Must be under 1 MB
- Remove unnecessary metadata

## Resources

### Icon Design Tools
- [Figma](https://www.figma.com) - Free design tool
- [Canva](https://www.canva.com) - Easy design platform
- [GIMP](https://www.gimp.org) - Free Photoshop alternative

### Icon Libraries
- [Flaticon](https://www.flaticon.com) - Free icons
- [Icons8](https://www.icons8.com) - Free icons
- [The Noun Project](https://thenounproject.com) - Simple icons

### Optimization
- [TinyPNG](https://tinypng.com) - Compress PNG
- [Squoosh](https://squoosh.app) - Image optimization

---

Once you create and add `icon.png` to the `SnapLayout.Trigger/` folder, your package will display beautifully on NuGet.org! 🎨
