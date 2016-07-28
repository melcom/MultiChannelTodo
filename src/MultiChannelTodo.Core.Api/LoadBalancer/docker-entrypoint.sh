#!/bin/sh
service haproxy start

#generate config
consul-template -consul=$CONSUL_URL -template="/templates/template.cfg:/etc/haproxy/haproxy.cfg:service haproxy reload"