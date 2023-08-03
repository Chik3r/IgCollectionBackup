Instagram Collections Backup
===
A command-line tool to download saved collections from your instagram profile.

## Projects
### IgCollectionBackup
A .NET 7 console application that takes in Instagram credentials and downloads the selected collections to a folder.

You can get your credentials by opening Instagram in a browser, logging in, and checking a request in the network tab of the developer tools.
You'll need to copy the cookies and `x-asbd-id`, `x-crsf-token`, `x-ig-app-id`, and `x-ig-www-claim` headers from the request.
#### Usage
```bash
$ IgCollectionBackup.exe
Enter your Instagram cookie: ---
Enter your Instagram asbdId: ---
Enter your Instagram crsfToken: ---
Enter your Instagram igAppId: ---
Enter your Instagram igWwwClaim: ---

Select collections to backup

  [ ] All Posts [2263 items]
> [X] Wallpaper [10 items]

Downloading collection: Wallpaper

Download ---------------------------------------- 100%
```


### InstagramApi
A simple wrapper around a small part of the Instagram API.