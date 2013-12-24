# Lightstreamer - Basic Stock-List Demo - .NET Client #
<!-- START DESCRIPTION Basic Stock-List Demo -->

This project contains a full example of a .NET client application that employs the .NET client library.

<table>
  <tr>
    <td style="text-align: left">
      &nbsp;<a href="http://www.lightstreamer.com/demo/DotNetDemo/DotNetClientDemo_N2.msi" target="_blank"><img src="screen_dotnet.png"></a>&nbsp;
      
    </td>
    <td>
      &nbsp;Click here to download and install the application:<br>
      &nbsp;<a href="http://www.lightstreamer.com/demo/DotNetDemo/DotNetClientDemo_N2.msi" target="_blank">http://www.lightstreamer.com/demo/DotNetDemo/DotNetClientDemo_N2.msi</a>
    </td>
  </tr>
</table>

This is a .NET version of the [Lightstreamer- Basic Stock-List Demo - HTML Client](https://github.com/Weswit/Lightstreamer-example-Stocklist-client-javascript#basic-stock-list-demo---html-client), where thirty items are subscribed to.<br>

This app uses the <b>.NET Client API for Lightstreamer</b> to handle the communications with Lightstreamer Server. A simple user interface is implemented to display the real-time data received from Lightstreamer Server.
The application uses a grid to display the real-time data. You can resize and drag the columns around.
<!-- END DESCRIPTION Basic Stock-List Demo -->

# Build #

If you want to skip the build and deploy processes of this demo please note that you can download a Windows Installer ([DotNetClientDemo_N2.msi](http://demos.lightstreamer.com/DotNetDemo/DotNetClientDemo_N2.msi)) and run locally the demo.

The example is comprised of the following source code and image files:
* Source/*
* Properties/*
* Images/*

To recompile the provided source, you just need to create a project for a Windows Application target, then include the source and include references to the .NET Client API for Lightstreamer binaries files DotNetClient_N2.dll and DotNetClient_N2.pdb from the [latest Lightstreamer  distribution](http://www.lightstreamer.com/download). You can find it in "/DOCS-SDKs/sdk_adapter_dotnet/lib" folder.

# Deploy #

Once you have generated the Demo Client binaries (DotNetClientDemo_N2.exe) you should create a deploy folder, let's call it "Deployment", and copy the binaries here. Then get the .NET Client API for Lightstreamer binaries files (see above) and put them in the "Deployment" folder.
Now you can prepare a  DotNetClient.bat launch script such this:
```cmd
@echo off

rem ---------------------------------------------------------------------------
rem Set the DotNet installation path as the current directory. Change the 
rem directory accordingly to your installation path of DotNet Adapter.

pushd .


rem ---------------------------------------------------------------------------
rem Start the StockList Demo Client, specifiyng to connect to the local
rem Lightstreamer Server instance.

start "DotNetStockListDemo" DotNetStockListDemo localhost 8080


rem ---------------------------------------------------------------------------
rem All done. Goes back to the original current directory and pauses, in case 
rem of any error.

echo Processes started. All done.
popd
pause
```

The DotNetClientDemo_N2 executable can also be run by double-clicking it; in its default configuration, the client will try to connect to Lightstreamer server at http://localhost:80.
In this case the [QUOTE_ADAPTER](https://github.com/Weswit/Lightstreamer-example-Stocklist-adapter-java) and [LiteralBasedProvider](https://github.com/Weswit/Lightstreamer-example-ReusableMetadata-adapter-java) have to be deployed in your local Lightstreamer server instance. The factory configuration of Lightstreamer server already provides this adapter deployed.<br>


# See Also #

## Lightstreamer Adapters needed by this demo ##
<!-- START RELATED_ENTRIES -->

* [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Weswit/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer - Reusable Metadata Adapters - Java Adapter](https://github.com/Weswit/Lightstreamer-example-ReusableMetadata-adapter-java)
* [Lightstreamer - Stock-List Demo - .NET Adapter](https://github.com/Weswit/Lightstreamer-example-StockList-adapter-dotnet)

<!-- END RELATED_ENTRIES -->
## Similar demo clients that may interest you ##

* [Lightstreamer - Stock-List Demos - HTML Clients](https://github.com/Weswit/Lightstreamer-example-Stocklist-client-javascript)
* [Lightstreamer - Basic Stock-List Demo - jQuery (jqGrid) Client](https://github.com/Weswit/Lightstreamer-example-StockList-client-jquery)
* [Lightstreamer - Stock-List Demo - Dojo Toolkit Client](https://github.com/Weswit/Lightstreamer-example-StockList-client-dojo)
* [Lightstreamer - Basic Stock-List Demo - Java SE (Swing) Client](https://github.com/Weswit/Lightstreamer-example-StockList-client-java)
* [Lightstreamer - Portfolio Demo - Flex Client](https://github.com/Weswit/Lightstreamer-example-Portfolio-client-flex)

# Lightstreamer Compatibility Notes #

- Compatible with Lightstreamer .NET Client Library version 2.1 or newer.
- For Lightstreamer Allegro (+ .NET Client API support), Presto, Vivace.
