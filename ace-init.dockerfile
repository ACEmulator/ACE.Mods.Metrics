# Use an official Debian image as the base
FROM debian:stable-slim

# Map folders
VOLUME /ace/Dats /ace/Mods

# Install curl, megatools, wget, p7zip and their dependencies
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl \
    wget \
    p7zip-full \
    megatools \
    ca-certificates \
    libcurl4 \
    libglib2.0-0 \
    libssl3 && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY ace-init.sh /app/ace-init.sh
RUN chmod +x /app/ace-init.sh

ENTRYPOINT ["/app/ace-init.sh"]
