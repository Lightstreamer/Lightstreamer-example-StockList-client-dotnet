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
using System.Collections.Generic;
using System.Text;

using Lightstreamer.DotNet.Client;

namespace DotNetStockListDemo
{

    class StocklistHandyTableListener : IHandyTableListener {
        private int phase;
        private StocklistClient slClient;

        public StocklistHandyTableListener(StocklistClient slClient, int phase) {

            this.phase = phase;
            this.slClient = slClient;
        }

        public void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            this.slClient.UpdateReceived(this.phase, itemPos, update);
        }

        public void OnRawUpdatesLost(int itemPos, string itemName, int lostUpdates)
        {
        }

        public void OnSnapshotEnd(int itemPos, string itemName)
        {
        }

        public void OnUnsubscr(int itemPos, string itemName)
        {
        }

        public void OnUnsubscrAll() {
        }
    }

}

