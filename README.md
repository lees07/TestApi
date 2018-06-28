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
$ git remote add origin https://github.com/<your account>/TestApi.git
$ git remote -v
```
under project directory to add remote repository, and run 
```
$ git pull https://github.com/<your account>/TestApi.git
$ git push -u origin master
```
to synchonize changes to github.


