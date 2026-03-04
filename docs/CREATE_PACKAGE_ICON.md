# Creating Your Package Icon

This guide will help you create and add a professional icon for your SnapLayout.Trigger NuGet package.

## Requirements

- **Size**: 128x128 pixels (required by NuGet)
- **Format**: PNG with transparency
- **File name**: `icon.png`
- **Location**: `SnapLayout.Trigger/icon.png` (same folder as `.csproj`)

## Design Suggestions

Your icon should visually represent the Snap Layout functionality. Here are some ideas:

### Option 1: Grid Pattern (Simple & Effective)
- Four colored rectangles in a 2x2 grid
- Colors: Blue, Green, Orange, Purple (Windows 11 style)
- White borders between sections
- Background: Solid color or gradient

### Option 2: Window with Snap Zones
- Simplified window outline
- Grid overlay showing snap zones
- Minimalist, flat design
- Windows 11 color scheme

### Option 3: "SL" Monogram
- Large "SL" letters (Snap Layout)
- Modern sans-serif font
- Solid background color (#0078D4 - Windows blue)
- White or light text

## Color Scheme Suggestions

Use Windows 11 colors for brand consistency:

- **Primary Blue**: `#0078D4`
- **Accent Colors**: 
  - Blue: `#0078D4`
  - Green: `#107C10`
  - Orange: `#FF8C00`
  - Purple: `#5C2D91`

## Tools to Create Your Icon

### Free Online Tools
1. **Canva** (canva.com)
   - Use "Custom dimensions" → 128x128 px
   - Search templates for "app icon" or "logo"
   - Export as PNG

2. **Figma** (figma.com)
   - Free for individual use
   - Professional design tools
   - Export as PNG at 1x scale

3. **Microsoft Designer** (designer.microsoft.com)
   - AI-powered design
   - Prompt: "Create a modern icon for a Windows 11 snap layout library, showing four window zones in a grid, minimalist flat design"

### Desktop Tools
1. **Paint.NET** (Windows, free)
2. **GIMP** (Cross-platform, free)
3. **Adobe Photoshop/Illustrator** (Paid)

## Quick Start: Simple Icon with Paint.NET

1. **Create new image**: 128x128 pixels
2. **Add background**: Fill with #0078D4 (Windows blue)
3. **Draw grid**: 
   - Use Rectangle Select tool
   - Create 4 squares (60x60 each)
   - Fill with different colors
   - Leave 4px gaps for borders
4. **Save**: File → Save As → PNG

## AI Generation Prompt

If using AI image generators (DALL-E, Midjourney, Bing Creator):

```
Create a simple, modern app icon for a Windows 11 snap layout library.
Design shows four colored rectangles arranged in a 2x2 grid pattern.
Colors: blue #0078D4, green #107C10, orange #FF8C00, purple #5C2D91.
Minimalist flat design, clean borders, 128x128 pixels, PNG format.
```

## Example Design ASCII Representation

```
┌────────────────────────────┐
│  ┌─────────┬─────────┐    │
│  │  Blue   │  Green  │    │
│  │ #0078D4 │ #107C10 │    │
│  ├─────────┼─────────┤    │
│  │ Orange  │ Purple  │    │
│  │ #FF8C00 │ #5C2D91 │    │
│  └─────────┴─────────┘    │
└────────────────────────────┘
```

## After Creating the Icon

1. **Save as** `icon.png` (exactly this name)
2. **Place in** `SnapLayout.Trigger/` folder
3. **Verify size**: Right-click → Properties → Details → Should show 128x128
4. **Test locally**:
   ```bash
   dotnet pack SnapLayout.Trigger/SnapLayout.Trigger.csproj --configuration Release
   ```
5. **Check the .nupkg**: Rename to .zip and verify icon.png is inside

## Troubleshooting

### Icon not showing in NuGet package
- Verify file name is exactly `icon.png` (case-sensitive)
- Check file is in correct location
- Ensure `.csproj` has both `<PackageIcon>` and `<None Include>` entries
- Run `dotnet clean` then rebuild

### Icon appears blurry
- Ensure source image is exactly 128x128 px
- Don't upscale a smaller image
- Use PNG format with proper DPI

### Icon has wrong colors
- Use PNG format (supports transparency)
- Save with sRGB color profile
- Avoid gradients that might render poorly

## Resources

- [NuGet Package Icon Guidelines](https://docs.microsoft.com/en-us/nuget/reference/nuspec#icon)
- [Windows 11 Design Guidelines](https://docs.microsoft.com/en-us/windows/apps/design/)
- [Flat Icon Design Best Practices](https://www.flaticon.com/blog/best-practices-icon-design/)

---

**Current Status**: Icon configuration is already in your `.csproj` file. You just need to create the `icon.png` file!
