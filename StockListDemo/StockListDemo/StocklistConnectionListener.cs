#region License
/*
 * Copyright (c) Lightstreamer Srl
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion License

using System;
using com.lightstreamer.client;

namespace DotNetStockListDemo
{

    class StocklistConnectionListener : ClientListener {
        public const int VOID = -1;
        public const int DISCONNECTED = 0;
        public const int POLLING = 1;
        public const int STREAMING = 2;
        public const int STALLED = 3;

        private StocklistClient slClient;
        private int phase;

        public StocklistConnectionListener(
                StocklistClient slClient,
                int phase)
        {

            this.slClient = slClient;
            this.phase = phase;
        }

        private void OnDisconnection(String status) {
            this.slClient.StatusChanged(this.phase, DISCONNECTED, status);
            this.slClient.Start(this.phase);
        }

        public void OnClose() {
            this.OnDisconnection("Connection closed");
        }

		public void OnEnd(int cause) {
            this.OnDisconnection("Connection forcibly closed");
		}

        void ClientListener.onListenEnd()
        {
            // ...
        }

        void ClientListener.onListenStart()
        {
            // ...
        }

        void ClientListener.onServerError(int errorCode, string errorMessage)
        {
            this.OnDisconnection("Server Error " + errorCode + " - " + errorMessage);
        }

        void ClientListener.onStatusChange(string status)
        {
            if ( status.StartsWith("CONNECTED:WS") )
            {
                if (status.EndsWith("POLLING"))
                {
                    this.slClient.StatusChanged(this.phase, POLLING, "Connected over Webscocket in polling mode");
                }
                else if (status.EndsWith("STREAMING"))
                {
                    this.slClient.StatusChanged(this.phase, STREAMING, "Connected over Websocket in streaming mode");
                }
            }
            else if ( status.StartsWith("CONNECTED:HT") )
            {
                if (status.EndsWith("POLLING"))
                {
                    this.slClient.StatusChanged(this.phase, POLLING, "Connected over HTTP in polling mode");
                }
                else if (status.EndsWith("STREAMING"))
                {
                    this.slClient.StatusChanged(this.phase, STREAMING, "Connected over HTTP in streaming mode");
                }
            }
            else if (status.StartsWith("CONNECTING"))
            {
                this.slClient.StatusChanged(this.phase, VOID, "Connecting to Lightstreamer Server...");
            }
            else if (status.StartsWith("DISCONNECTED"))
            {
                this.slClient.StatusChanged(this.phase, DISCONNECTED, "Disconnected");
            }
            else if (status.StartsWith("STALLED"))
            {
                this.slClient.StatusChanged(this.phase, STALLED, "Connection stalled");
            }
        }

        void ClientListener.onPropertyChange(string property)
        {
            // ...
        }
    }

}
