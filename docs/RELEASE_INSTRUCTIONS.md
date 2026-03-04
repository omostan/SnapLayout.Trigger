# Release Instructions for SnapLayout.Trigger

This document provides step-by-step instructions for releasing new versions of SnapLayout.Trigger to GitHub and NuGet.

## Prerequisites

Before releasing, ensure you have:

1. **GitHub Account** with write access to the repository
2. **NuGet API Key** from https://www.nuget.org/account/apikeys
3. **Git** installed and configured
4. **.NET 10 SDK** installed
5. **Visual Studio 2022** or later (optional)

## Pre-Release Checklist

- [ ] All tests pass locally (`dotnet test`)
- [ ] Code builds without warnings (`dotnet build`)
- [ ] Example project runs successfully
- [ ] Documentation is up to date
- [ ] CHANGELOG.md is updated with new version details
- [ ] Version number follows Semantic Versioning (SemVer)

## Version Numbering (Semantic Versioning)

Follow [Semantic Versioning 2.0.0](https://semver.org/):

- **MAJOR** version (X.0.0): Incompatible API changes
- **MINOR** version (0.X.0): New functionality in a backward-compatible manner
- **PATCH** version (0.0.X): Backward-compatible bug fixes

Examples:
- Bug fix: 1.0.0 → 1.0.1
- New feature: 1.0.1 → 1.1.0
- Breaking change: 1.1.0 → 2.0.0

## Release Steps

### 1. Update Version Number

Update the version in `SnapLayout.Trigger\SnapLayout.Trigger.csproj`:

```xml
<PropertyGroup>
  <Version>1.1.0</Version>
</PropertyGroup>
```

### 2. Update CHANGELOG.md

Move changes from `[Unreleased]` to a new version section:

```markdown
## [1.1.0] - 2025-01-28

### Added
- New feature description

### Fixed
- Bug fix description
```

Update the links at the bottom:

```markdown
[Unreleased]: https://github.com/omostan/SnapLayout.Trigger/compare/v1.1.0...HEAD
[1.1.0]: https://github.com/omostan/SnapLayout.Trigger/compare/v1.0.0...v1.1.0
```

### 3. Commit Changes

```bash
git add .
git commit -m "Release v1.1.0"
git push origin main
```

### 4. Create Git Tag

```bash
git tag -a v1.1.0 -m "Release version 1.1.0"
git push origin v1.1.0
```

### 5. Create GitHub Release

1. Go to https://github.com/omostan/SnapLayout.Trigger/releases
2. Click "Draft a new release"
3. Choose the tag you just created (v1.1.0)
4. Set the release title: "SnapLayout.Trigger v1.1.0"
5. Copy the relevant section from CHANGELOG.md to the description
6. Check "Set as the latest release"
7. Click "Publish release"

**The GitHub Action will automatically:**
- Build the project
- Run tests
- Create NuGet package
- Publish to NuGet.org (requires `NUGET_API_KEY` secret to be configured)

### 6. Verify NuGet Package

1. Wait for the GitHub Action to complete (check the Actions tab)
2. Verify the package appears on https://www.nuget.org/packages/SnapLayout.Trigger/
3. Test installing the package in a sample project:
   ```bash
   dotnet add package SnapLayout.Trigger --version 1.1.0
   ```

## Manual NuGet Publishing (If GitHub Actions Fail)

If you need to manually publish:

### 1. Build and Pack

```bash
dotnet build --configuration Release
dotnet pack SnapLayout.Trigger\SnapLayout.Trigger.csproj --configuration Release --output ./artifacts
```

### 2. Push to NuGet

```bash
dotnet nuget push ./artifacts/SnapLayout.Trigger.1.1.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## Configuring GitHub Secrets

### NuGet API Key Secret

1. Generate an API key at https://www.nuget.org/account/apikeys
   - Click "Create"
   - Key Name: "SnapLayout.Trigger GitHub Actions"
   - Glob Pattern: "SnapLayout.Trigger"
   - Select: "Push" and "Push new packages and package versions"
   - Expires: Choose an expiration date

2. Add the secret to GitHub:
   - Go to repository Settings → Secrets and variables → Actions
   - Click "New repository secret"
   - Name: `NUGET_API_KEY`
   - Value: Paste your API key
   - Click "Add secret"

### CodeCov Token (Optional)

For code coverage reports:

1. Sign up at https://codecov.io/
2. Add your repository
3. Copy the token
4. Add as `CODECOV_TOKEN` secret in GitHub

## Post-Release Tasks

- [ ] Announce the release on social media/forums (optional)
- [ ] Update any dependent projects
- [ ] Monitor for issues and bug reports
- [ ] Update documentation website if applicable

## Rollback Instructions

If you need to unlist or delete a package:

### Unlist on NuGet
1. Go to https://www.nuget.org/packages/SnapLayout.Trigger/
2. Click "Manage Package"
3. Select the version
4. Click "Unlist"

### Delete from NuGet (within 10 days)
1. Same steps as unlist
2. Click "Delete" instead

**Note:** Deletion is only possible within 10 days of publishing.

## Troubleshooting

### Build Fails
- Ensure all dependencies are restored: `dotnet restore`
- Check for compilation errors: `dotnet build`
- Verify .NET 10 SDK is installed: `dotnet --version`

### Tests Fail
- Run tests locally: `dotnet test --verbosity detailed`
- Check test output for specific failures
- Ensure Windows 11 for Snap Layout testing

### NuGet Push Fails
- Verify API key is valid and not expired
- Check package ID and version don't conflict with existing packages
- Ensure you have permission to push to the package ID

### GitHub Action Fails
- Check the Actions tab for detailed logs
- Verify secrets are configured correctly
- Ensure workflow YAML syntax is correct

## Support

For questions or issues with the release process:
- Create an issue on GitHub
- Contact: support@omotech.com

---

Last updated: 2025-01-27
