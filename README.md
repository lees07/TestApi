# TestApi

This is my first Dotnet Core sample project runs on docker/linux.

When use ASPDOTNET Core to serve restful api, you will meet error like "error:2006D002:BIO routines:BIO_new_file:system lib".
It's caused by certificates in /etc/pki/tls/certs/* are readonly for root user.
You need to run
```
# chmod +r /etc/pki/tls/certs/*
```
to fix such issue.

Add project to github.com, you will run
```
$ git init
$ git add *
$ git commit -m "first commit"
$ git remote add origin https://github.com/<your account>/<your repository>.git
$ git push -u origin master
```
under project directory to add remote repository, and run 
```
$ git pull https://github.com/<your account>/<your repository>.git
$ git push -u origin master
```
to synchonize changes to github.

Build and deploy project to Openshift is sample.
```
oc new-app registry.access.redhat.com/dotnet/dotnet-21-rhel7~https://github.com/<your account>/<your repository> --context-dir=app
```
can triggered S2I process, download dotnet-21-rhel7 images from registry, clone source codes from github, build an application image, and deploy to run.
