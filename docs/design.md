# Command Design

The CLI will try to mirror GitHub's REST API as closely as possible except in cases where it doesn't make sense to do so. The GhBulk CLI will not try to replace the GitHub API. It provides functionality to do bulk operations that are not available in the GitHub API. For example, the GitHub API does not provide a way to delete multiple repositories at once. The GhBulk CLI will provide this functionality. An example of a command that will not be implemented is the ability to fetch multiple repositories at once. This is already possible with the GitHub API.

## Commands

The following commands will be implemented:

### repo
 - create
 - delete
 - update

 