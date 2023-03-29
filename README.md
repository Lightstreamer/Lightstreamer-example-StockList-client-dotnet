# Lightstreamer - Basic Stock-List Demo - .NET Client

<!-- START DESCRIPTION lightstreamer-example-stocklist-client-dotnet -->

This project contains a full example of a .NET Framework client application that employs the [.NET Standard client API for Lightstreamer](https://lightstreamer.com/api/ls-dotnetstandard-client/latest/).

## Live Demo

[![screenshot](screen_dotnet_large.png)](https://demos.lightstreamer.com/DotNetDemo/deploy_push.zip)<br>

### [![](http://demos.lightstreamer.com/site/img/play.png) View live demo](https://demos.lightstreamer.com/DotNetDemo/deploy_push.zip)<br>
(download deploy_push.zip; unzip it; launch setup.exe; follow the instructions)

## Details

This is a .NET desktop version of the [Lightstreamer - Basic Stock-List Demo - HTML Client](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-client-javascript#basic-stock-list-demo---html-client), where thirty items are subscribed to.<br>

This app uses the <b>.NET Standard Client API for Lightstreamer</b> to handle the communications with Lightstreamer Server. A simple user interface is implemented to display the real-time data received from Lightstreamer Server.
The application uses a grid to display the real-time data. You can resize and drag the columns around.
<br>
This application uses the LightstreamerClient class to connect to Lightstreamer Server and subscribe to the 30 items. The client library offers auto-reconnection and auto-resubscription logic out of the box. The status of the connection can be seen on the top right corener or in the bottom statys bar of the demo. 
A *DataGridview* object from System.Windows.Forms is used to display the real-time updates received from Lightstreamer Server. The application code implements a cell highlighting mechanism, too.

At the top right of the form there are few controls that allow you to:
 * dynamically  change the transport over which the client session with the Lightstremer server is based;
 * reset the connection with the Lightstreamer server  to force a new client session;
 * dynamically  change the max updates frequency allowed for the subscription, varying from unlimited to 1 update every 100 seconds.

Double-clicking on the last column a new Form will be shown with a *Chart* object from System.Windows.Forms.DataVisualization drawing a real-time serie for the quotes of the related stock.
Each new Chart form involves a new Subscription in order to be totally released from any limitation on the frequency of updates imposed on the main subscription of the grid. 

<!-- END DESCRIPTION lightstreamer-example-stocklist-client-dotnet -->

## Install 

If you want to install a version of this demo pointing to your local Lightstreamer Server, follow these steps:

* Note that, as prerequisite, a windows system is required and the [Lightstreamer - Stock- List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-adapter-java) has to be deployed on your local Lightstreamer Server instance. Please check out that project and follow the installation instructions provided with it.
* Launch Lightstreamer Server.
* Download the `publish.zip` file that you can find in the [latest release](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-dotnet/releases) of this project and extract it in your local file system.
* Execute `StockListDemo.exe` and enjoy it.


## Build

The Visual Studio project provided in this project was created from the 'Windows Forms App' template and specify as target framework: .NET 6.0.

## See Also

### Lightstreamer Adapters Needed by These Demo Clients
<!-- START RELATED_ENTRIES -->

* [Lightstreamer - Stock-List Demo - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer - Reusable Metadata Adapters - Java Adapter](https://github.com/Lightstreamer/Lightstreamer-example-ReusableMetadata-adapter-java)
* [Lightstreamer - Stock-List Demo - .NET Adapter](https://github.com/Lightstreamer/Lightstreamer-example-StockList-adapter-dotnet)

<!-- END RELATED_ENTRIES -->
### Related Projects

* [Lightstreamer .NET Standard Client SDK](https://www.nuget.org/packages/Lightstreamer.DotNetStandard.Client)
* [Lightstreamer - Stock-List Demos - HTML Clients](https://github.com/Lightstreamer/Lightstreamer-example-Stocklist-client-javascript)
* [Lightstreamer - Basic Stock-List Demo - jQuery (jqGrid) Client](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-jquery)
* [Lightstreamer - Basic Stock-List Demo - Java SE (Swing) Client](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-java)
* [Lightstreamer - Quickstart Example - .NET Client](https://github.com/Lightstreamer/Lightstreamer-example-Quickstart-client-dotnet)

## Lightstreamer Compatibility Notes

* Compatible with Lightstreamer .NET Standard Client Library version 6.x.
* Ensure that .NET Standard Client API is supported by your Lightstreamer Server license configuration.
* For instructions compatible with .NET Standard Client library version 5.x, please refer to [this tag](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-dotnet/releases/tag/deploy-for-client-5)
* For instructions compatible with .NET Standard Client library version 4.x, please refer to [this tag](https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-dotnet/tree/deploy2)