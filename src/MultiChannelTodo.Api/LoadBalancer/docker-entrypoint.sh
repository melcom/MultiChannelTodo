#!/bin/sh
consul-template -consul=$CONSUL_URL -template="/templates/template.cfg:/usr/local/etc/haproxy/haproxy.cfg" -once

# first arg is `-f` or `--some-option`
if [ "${1#-}" != "$1" ]; then
        set -- haproxy "$@"
fi

if [ "$1" = 'haproxy' ]; then
        # if the user wants "haproxy", let's use "haproxy-systemd-wrapper" instead so we can have proper reloadability implemented by upstream
        shift # "haproxy"
        set -- "$(which haproxy-systemd-wrapper)" -p /run/haproxy.pid "$@"
fi

exec "$@"