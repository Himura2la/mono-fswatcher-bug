FROM mono
RUN apt-get update && apt-get install htop
WORKDIR /app
COPY . .
RUN msbuild .
WORKDIR /app/bin/Debug/
CMD [ "bash" ]