FROM ubuntu:latest

RUN apt-get update

RUN apt-get install -y unzip haproxy

# debug network tools
RUN apt-get install -y curl net-tools inetutils-ping

RUN rm -rf /var/lib/apt/lists/*

ADD https://releases.hashicorp.com/consul-template/0.15.0/consul-template_0.15.0_linux_amd64.zip /usr/bin/
RUN unzip /usr/bin/consul-template_0.15.0_linux_amd64.zip -d /usr/local/bin
ADD template.cfg /templates/template.cfg

# Add entrypoint
COPY docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
