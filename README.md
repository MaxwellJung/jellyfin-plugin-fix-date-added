# Fix Date Added

Makes Jellyfin's "Date added" behave like Plex: when Radarr or Sonarr
upgrades a file, the original date is kept so it stays out of "Recently Added".

Status: experimental — use at your own risk.

> **Note:** This plugin is heavily vibe coded. Treat it accordingly.

## Install from catalog

1. In Jellyfin: **Dashboard → Plugins → Repositories → +**
2. Add repository URL:

   ```text
   https://raw.githubusercontent.com/MaxwellJung/jellyfin-plugin-fix-date-added/main/manifest.json
   ```

3. **Catalog** → find **Fix Date Added** → Install → restart Jellyfin.

## Build and install manually

Requires Jellyfin 10.11 and the .NET SDK.

```bash
dotnet build -c Release
```

Copy `Jellyfin.Plugin.FixDateAdded/bin/Release/net9.0/Jellyfin.Plugin.FixDateAdded.dll`
to a `FixDateAdded` folder in Jellyfin's `plugins` folder and restart Jellyfin.

## How it works

Jellyfin treats an upgraded file (new filename) as a new item with a new
date added. Fix Date Added records the earliest date added it has seen for
each title when Jellyfin removes or updates a movie or episode, and restores
that date when a replacement shows up newer. Titles are keyed by every
stable id Jellyfin exposes (IMDb, TMDb, and episode series+season+episode
keys).

Dates are stored in
`plugins/configurations/Jellyfin.Plugin.FixDateAdded.json`.

Only upgrades that happen **after** the plugin is installed are covered.
Media upgraded before install is unaffected (those titles were never recorded).
To cover older upgrades, you can prepopulate
`Jellyfin.Plugin.FixDateAdded.json` yourself (map stable ids → earliest
dates). Building that seed is **out of scope** for this plugin; use a small
script (e.g. Python) if you need it. Sample Radarr/Sonarr seed scripts:
[#22](https://github.com/MaxwellJung/jellyfin-plugin-fix-date-added/issues/22).

## Releases

Releases use [release-please](https://github.com/googleapis/release-please)
and [Conventional Commits](https://www.conventionalcommits.org/).

1. Open PRs whose **title** starts with `feat:`, `fix:`, `chore:`, etc.
   (CI enforces this; squash merges use the PR title as the commit subject.)
2. After merges to `main`, release-please opens or updates a **Release PR**.
3. Merge that Release PR to cut the next semver tag and GitHub Release.
4. CI uploads the plugin zip and pushes a `manifest.json` update to `main`
   so the Jellyfin catalog refreshes — one merge is the whole release.

Git keeps 3-part semver (`v0.1.1`); publish writes Jellyfin 4-part (`0.1.1.0`).

One-time: fine-grained PAT (Contents + Pull requests read/write) as secret
`RELEASE_PLEASE_TOKEN`, and uncheck **Include administrators** on `main`
branch protection so that PAT can push the catalog commit.

`fix:` → patch, `feat:` → minor, `BREAKING CHANGE` → major. Below 1.0.0,
`feat` bumps patch and breaking bumps minor.

## Test

```bash
./tests/regression.sh
```

Needs Docker and Python 3. CI runs this on every pull request.

## License

[GPLv3](LICENSE)
