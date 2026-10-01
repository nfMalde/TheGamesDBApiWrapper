#!/usr/bin/env bash
# Extract a single version's section from a Keep-a-Changelog file and emit two forms:
#   <out-md>  : the section verbatim (Markdown)  — for the GitHub Release body.
#   <out-txt> : the same section flattened to plain text — for NuGet's release-notes field,
#               which does NOT render Markdown.
#
# Usage: release-notes.sh <changelog-path> <version> <out-md> <out-txt>
set -euo pipefail

CHANGELOG="$1"
VERSION="$2"
OUT_MD="$3"
OUT_TXT="$4"

if [[ ! -f "$CHANGELOG" ]]; then
  : > "$OUT_MD"; : > "$OUT_TXT"
  echo "release-notes: changelog not found: $CHANGELOG" >&2
  exit 0
fi

# Grab from "## [VERSION]" up to (but not including) the next "## [" heading.
awk -v hdr="## [$VERSION]" '
  index($0, hdr) == 1 { grab = 1; print; next }
  grab && /^## \[/    { exit }
  grab                { print }
' "$CHANGELOG" > "$OUT_MD"

# Flatten Markdown to plain text for NuGet (headings, inline code, bold, links).
sed -E \
  -e 's/^#{1,6}[[:space:]]+//' \
  -e 's/`([^`]*)`/\1/g' \
  -e 's/\*\*([^*]+)\*\*/\1/g' \
  -e 's/\[([^]]+)\]\(([^)]+)\)/\1 (\2)/g' \
  "$OUT_MD" > "$OUT_TXT"
