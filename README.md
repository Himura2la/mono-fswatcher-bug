```
$ docker build --tag mono_test .
$ docker run --name mono_test --rm -it mono_test bash

root@69c54b58dc68:/app/bin/Debug# mono MonoFSWatcherBug.exe -n   # normal behavior
root@69c54b58dc68:/app/bin/Debug# mono MonoFSWatcherBug.exe      # bug

# watch for the threads and cpu load in another console
docker exec -it mono_test htop
```