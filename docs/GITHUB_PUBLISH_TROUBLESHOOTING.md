# GitHub Publishing Troubleshooting Guide

## Issues Fixed in publish.yml

### 1. ✅ .NET Version Issue
**Problem:** Workflow was using `dotnet-version: '10.0.x'` which doesn't exist yet.  
**Fix:** Changed to `dotnet-version: '9.0.x'` (latest available)

### 2. ✅ Path Separator Issue  
**Problem:** Using backslash `\` in path `SnapLayout.Trigger\SnapLayout.Trigger.csproj`  
**Fix:** Changed to forward slash `/` for cross-platform compatibility

### 3. ✅ Added Environment Variable
**Problem:** NuGet API key not explicitly set as environment variable  
**Fix:** Added `env: NUGET_API_KEY: ${{ secrets.NUGET_API_KEY }}` to publish step

## Common Publishing Errors and Solutions

### Error: "Unable to load the service index for source"
**Cause:** Network connectivity or NuGet.org down  
**Solution:** 
- Wait and retry
- Check https://status.nuget.org/
- Verify NuGet API key is valid

### Error: "Response status code does not indicate success: 401 (Unauthorized)"
**Cause:** Invalid or expired NuGet API key  
**Solution:**
1. Go to https://www.nuget.org/account/apikeys
2. Generate a new API key
3. Update the `NUGET_API_KEY` secret in GitHub:
   - Go to repository **Settings** → **Secrets and variables** → **Actions**
   - Update or create secret named `NUGET_API_KEY`

### Error: "Response status code does not indicate success: 409 (Conflict)"
**Cause:** Package version already exists on NuGet  
**Solution:**
- Update version in `SnapLayout.Trigger.csproj`
- Create a new release with the updated version
- Note: `--skip-duplicate` flag is already in the workflow

### Error: ".NET SDK version not found"
**Cause:** Specified .NET version doesn't exist  
**Solution:**
- Use .NET 8.0 or 9.0 in GitHub Actions
- Projects can still target net10.0-windows locally

### Error: "No packages found to push"
**Cause:** Pack step failed or output directory is wrong  
**Solution:**
1. Check build logs for pack step errors
2. Verify output path: `./artifacts`
3. Ensure project builds successfully

## Verification Steps

### Before Publishing:
1. ✅ Verify secrets are configured in GitHub repository settings
2. ✅ Check that `NUGET_API_KEY` secret exists and is valid
3. ✅ Ensure version in `.csproj` is unique
4. ✅ Test build locally: `dotnet build --configuration Release`
5. ✅ Test pack locally: `dotnet pack --configuration Release`

### After Publishing:
1. ✅ Check GitHub Actions logs for errors
2. ✅ Verify package appears on NuGet.org (may take 5-10 minutes)
3. ✅ Test installation: `dotnet add package SnapLayout.Trigger --version X.X.X`

## Manual Publishing (If GitHub Actions Fails)

If automated publishing continues to fail, you can publish manually:

```bash
# Build and pack
dotnet build --configuration Release
dotnet pack SnapLayout.Trigger/SnapLayout.Trigger.csproj --configuration Release --output ./artifacts

# Publish to NuGet
dotnet nuget push ./artifacts/*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## Updated Workflow Files

Both workflow files have been updated:

### build.yml
- Changed .NET version from 10.0.x to 9.0.x
- Runs on: push to main/develop, pull requests

### publish.yml  
- Changed .NET version from 10.0.x to 9.0.x
- Fixed path separators (/ instead of \\)
- Added explicit environment variable for NuGet API key
- Added --no-restore flag to pack command
- Runs on: release published

## Testing the Workflow

### Test Build Workflow:
1. Make a small change and commit
2. Push to main branch
3. Check Actions tab for build results

### Test Publish Workflow:
1. Update version in `.csproj`
2. Commit and push
3. Create a git tag: `git tag -a v1.0.1 -m "Release 1.0.1"`
4. Push tag: `git push origin v1.0.1`
5. Create GitHub release using the tag
6. Check Actions tab for publish results

## Support

If issues persist:
1. Check GitHub Actions logs for detailed error messages
2. Verify all secrets are configured correctly
3. Ensure NuGet API key has proper permissions
4. Try manual publishing to isolate the issue

## Additional Resources

- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [NuGet Publishing Guide](https://docs.microsoft.com/en-us/nuget/nuget-org/publish-a-package)
- [.NET CLI Reference](https://docs.microsoft.com/en-us/dotnet/core/tools/)

---

Last Updated: 2025-01-27
