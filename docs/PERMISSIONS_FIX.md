# GitHub Actions Permissions Fix

## Error: Resource not accessible by integration

If you see this error when the workflow tries to upload release artifacts:

```
⚠️ Unexpected error fetching GitHub release for tag refs/tags/v1.0.1: HttpError: Resource not accessible by integration
Error: Resource not accessible by integration
```

## Root Cause

GitHub Actions workflows require explicit permissions to perform certain actions. By default, newer repositories have restricted `GITHUB_TOKEN` permissions for security reasons.

## Solution

Add the `permissions` block to your workflow file **before** the `jobs` section.

### For publish.yml (Release Publishing)

```yaml
name: Publish NuGet Package

on:
  release:
    types: [published]

permissions:
  contents: write      # Required to upload assets to releases
  packages: write      # Required to publish packages

jobs:
  publish:
    runs-on: windows-latest
    # ... rest of the workflow
```

### For build.yml (CI/CD)

```yaml
name: Build and Test

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main, develop ]

permissions:
  contents: read       # Required to checkout code
  checks: write        # Required to report test results
  pull-requests: write # Required to comment on PRs

jobs:
  build:
    runs-on: windows-latest
    # ... rest of the workflow
```

## Permission Types

### Common Permissions:
- **`contents: write`** - Upload/modify repository files, create releases, upload assets
- **`contents: read`** - Read repository contents (checkout)
- **`packages: write`** - Publish packages to GitHub Packages
- **`checks: write`** - Create check runs for test results
- **`pull-requests: write`** - Comment on pull requests
- **`issues: write`** - Create/edit issues

### Permission Levels:
- **`read`** - Read-only access
- **`write`** - Read and write access
- **`none`** - No access

## How to Apply the Fix

### Option 1: Update Workflow Files (Recommended)
The workflow files have already been updated with the correct permissions.

### Option 2: Repository Settings (Alternative)
If you want to grant default permissions at the repository level:

1. Go to your repository on GitHub
2. Click **Settings**
3. Navigate to **Actions** → **General**
4. Scroll to **Workflow permissions**
5. Select **"Read and write permissions"**
6. Click **Save**

**Note:** Option 1 (explicit permissions in workflow) is more secure and recommended.

## After Applying the Fix

1. **Commit and push the updated workflow files:**
   ```bash
   git add .github/workflows/publish.yml .github/workflows/build.yml
   git commit -m "Fix: Add workflow permissions for release asset upload"
   git push origin main
   ```

2. **Re-run the failed workflow:**
   - Go to the **Actions** tab on GitHub
   - Find the failed workflow run
   - Click **Re-run all jobs**

   **OR** trigger a new release:
   ```bash
   # Delete the tag locally and remotely
   git tag -d v1.0.1
   git push origin :refs/tags/v1.0.1
   
   # Delete the GitHub release (via web UI)
   # Then recreate the tag and release
   git tag -a v1.0.1 -m "Release version 1.0.1"
   git push origin v1.0.1
   
   # Create a new GitHub release from the tag
   ```

## Verifying the Fix

After re-running the workflow, you should see:

1. ✅ All steps complete successfully
2. ✅ NuGet package published to NuGet.org
3. ✅ `.nupkg` file attached to the GitHub release
4. ✅ No permission errors in the logs

## Additional Troubleshooting

### If the error persists:

1. **Check Repository Settings:**
   - Ensure Actions are enabled for the repository
   - Verify workflow permissions are not restricted

2. **Check Branch Protection:**
   - Branch protection rules might prevent workflow permissions
   - Temporarily disable or adjust rules

3. **Verify Token Expiration:**
   - `GITHUB_TOKEN` is automatically generated but check if there are any token issues
   - Try re-running the workflow

4. **Check Organization Settings:**
   - If in an organization, check organization-level workflow permission settings

## Security Best Practices

- ✅ Use minimal required permissions
- ✅ Specify permissions per workflow
- ✅ Avoid `permissions: write-all` unless absolutely necessary
- ✅ Use `read` when write is not needed
- ✅ Review permissions regularly

## Related Links

- [GitHub Actions Permissions](https://docs.github.com/en/actions/security-guides/automatic-token-authentication#permissions-for-the-github_token)
- [softprops/action-gh-release Documentation](https://github.com/softprops/action-gh-release)
- [GitHub Actions Security Best Practices](https://docs.github.com/en/actions/security-guides/security-hardening-for-github-actions)

---

**Status:** ✅ Fixed  
**Last Updated:** March 4, 2026
