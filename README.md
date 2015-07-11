# CSFtp - [A C# FTP Server](http://www.codeguru.com/csharp/csharp/cs_network/sockets/article.php/c7409/A-C-FTP-Server.htm)

This is a modified version of the FTP server developed by David McClarnon.
The original article and source can be found [here](http://www.codeguru.com/csharp/csharp/cs_network/sockets/article.php/c7409/A-C-FTP-Server.htm)

# Changes of my version:

* Dynamic PASV listener port
* Made handler processing and sending async
* Fixed PASV output to something that's understood by most FTP clients
* Fixed blocking UI when connection is active
* Fixed UI access from background thread
