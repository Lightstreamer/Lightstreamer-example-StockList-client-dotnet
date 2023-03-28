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
using com.lightstreamer.client;

namespace DotNetStockListDemo
{

    class StocklistSubscriptionListener : SubscriptionListener {
        private int phase;
        private StocklistClient slClient;

        public StocklistSubscriptionListener(StocklistClient slClient, int phase) {

            this.phase = phase;
            this.slClient = slClient;
        }

        public void OnUpdate(int itemPos, string itemName, ItemUpdate update)
        {
            this.slClient.UpdateReceived(this.phase, itemPos, update);
        }

        void SubscriptionListener.onClearSnapshot(string itemName, int itemPos)
        {
            // ...
        }

        void SubscriptionListener.onCommandSecondLevelItemLostUpdates(int lostUpdates, string key)
        {
            // ...
        }

        void SubscriptionListener.onCommandSecondLevelSubscriptionError(int code, string message, string key)
        {
            // ...
        }

        void SubscriptionListener.onEndOfSnapshot(string itemName, int itemPos)
        {
            // ...
        }

        void SubscriptionListener.onItemLostUpdates(string itemName, int itemPos, int lostUpdates)
        {
            // ...
        }

        void SubscriptionListener.onItemUpdate(ItemUpdate itemUpdate)
        {
            slClient.UpdateReceived(phase, itemUpdate.ItemPos, itemUpdate);
        }

        void SubscriptionListener.onListenEnd()
        {
            // ...
        }

        void SubscriptionListener.onListenStart()
        {
            // ...
        }

        void SubscriptionListener.onSubscription()
        {
            // ...
        }

        void SubscriptionListener.onSubscriptionError(int code, string message)
        {
            // ...
        }

        void SubscriptionListener.onUnsubscription()
        {
            // ...
        }

        void SubscriptionListener.onRealMaxFrequency(string frequency)
        {
            // ...
        }
    }

}

