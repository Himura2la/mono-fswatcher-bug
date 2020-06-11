This repo helps you reproduce a [FileSystemWatcher with NotifyFilters.LastAccess enters an endless loop when finds more then 4096 directories](https://github.com/mono/mono/issues/19956) bug, which I described in ![FileSystemWatcher under Mono: Heavy CPU load on Linux](https://stackoverflow.com/questions/62321603/filesystemwatcher-under-mono-heavy-cpu-load-on-linux) StackOverflow question


```
$ docker build --tag mono_test .
$ docker run --name mono_test --rm -it mono_test bash

root@69c54b58dc68:/app/bin/Debug# mono MonoFSWatcherBug.exe -n   # normal behavior
root@69c54b58dc68:/app/bin/Debug# mono MonoFSWatcherBug.exe      # bug

# watch for the threads and cpu load in another console
docker exec -it mono_test htop
```
