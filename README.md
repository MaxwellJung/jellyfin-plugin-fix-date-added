# Fix Date Added

A Jellyfin plugin that keeps a movie's or episode's original "Date added"
when Radarr or Sonarr upgrade its file, so upgrades don't jump to the top of
"Recently Added". Plex behaves this way already.

Status: in development, not ready for use.

## How it works

Jellyfin treats an upgraded file (new filename) as a new item with a new
date added. Fix Date Added records the earliest date added it has seen for
each title when Jellyfin removes or updates a movie or episode, and restores
that date when a replacement shows up newer. Titles are keyed by every
stable id Jellyfin exposes (IMDb, TMDb, and episode series+season+episode
keys).

Dates are stored in
`plugins/configurations/Jellyfin.Plugin.FixDateAdded.json`.

## Install from catalog

1. In Jellyfin: **Dashboard → Plugins → Repositories → +**
2. Add repository URL:

   ```text
   https://raw.githubusercontent.com/MaxwellJung/jellyfin-plugin-fix-date-added/main/manifest.json
   ```

3. **Catalog** → find **Fix Date Added** → Install → restart Jellyfin.

Versions appear after a GitHub release is published (see below).

## Build and install manually

Requires Jellyfin 10.11 and the .NET SDK.

```bash
dotnet build -c Release
```

Copy `Jellyfin.Plugin.FixDateAdded/bin/Release/net9.0/Jellyfin.Plugin.FixDateAdded.dll`
to a `FixDateAdded` folder in Jellyfin's `plugins` folder and restart Jellyfin.

## Publish a release

Tag a semver (`major.minor.patch`) and push (or run the **release** workflow
manually):

```bash
git tag v0.1.0
git push origin v0.1.0
```

CI builds the plugin, uploads a zip to a GitHub Release, and opens a PR that
prepends that version to `manifest.json` (merge it so the catalog updates).

## Test

```bash
./tests/regression.sh
```

Builds the plugin, runs it in a throwaway Jellyfin 10.11.10 container (no
network), fakes upgrades, and checks dates. Includes a regression for the
TMDb-vs-IMDb key mismatch (Piper-style folder move). Needs Docker and
Python 3. CI runs this regression test on every pull request.

## License

[GPLv3](LICENSE)
