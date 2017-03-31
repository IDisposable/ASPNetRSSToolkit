{{DownloadManager}} class is used to get fetch feeds. The feed contents are  cached locally to the disk. The location and duration of the caching is configurable. You can use the keys in the {{web.config}} to change the values.
{{
<appSettings>
        <add key="defaultRssTtl" value="10"/>
        <add key="rssTempDir" value="c:\temp"/>
</appSettings>
}}
The _defaultRssTtl_ value is used when a feed doesn't specify a time-to-live for the feed contents, otherwise the feed-supplied value is honored. The {{ttl}} value is also used to prune the on-disk cache of feed items. The default value for this is 1 minute if not specified in the {{web.config}}

The _rssTempDir_ value specifies the base directory for the cache of feed contents. The feed's absolute path is used in the naming of the cached contents to insure no collisions occur when multiple feeds are fetch by the same application. If the temporary directory value is not specified in the {{web.config}}, the value of the hosting environment's code-generation temporary directory will be used. If not running in a hosted environment (like ASP.Net inside a web site or web application, or inside SQL Server), then the value for the {{TEMP}} or {{TMP}} environment variable will be used.

Note, the naming convention of the feed cache files replaces the periods with underscores and appends a {{.feed}} extension to the feed so they are easily manually recognized.