site-warmer
===========

Windows service that issues requests to URLs to keep sites warm.

To configure the service, edit the App.Config. You can add as many Jobs as you require in the `jobs` collection of the `jobSection`.

Each job looks like this. 

    <job name="NEW JOB" 
           url="URL FOR WEB REQUEST TO BE PERFORMED"
           schedule="CRON FORMATED SCHEDULE" />

A job to hit google every hour would look like this:
    <job name="Google" 
           url="http://www.google.com"
           schedule="0 * 0/1 * * ?" />
