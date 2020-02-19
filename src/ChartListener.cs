using com.lightstreamer.client;
using System;

namespace DotNetStockListDemo
{
    internal class ChartListener : SubscriptionListener
    {
        string prefix = "";
        ChartQuotes chartForm = null;
        LightstreamerChartUpdateDelegate delegateChart = null;


        public ChartListener(string prefix, ChartQuotes chartForm)
        {
            this.prefix = prefix;
            this.chartForm = chartForm;
            this.delegateChart = new LightstreamerChartUpdateDelegate(chartForm.OnLightstreamerUpdate);

        }

        void SubscriptionListener.onClearSnapshot(string itemName, int itemPos)
        {
            Console.WriteLine("Clear Snapshot for " + itemName + ".");
        }

        void SubscriptionListener.onCommandSecondLevelItemLostUpdates(int lostUpdates, string key)
        {
            Console.WriteLine("Lost Updates for " + key + " (" + lostUpdates + ").");
        }

        void SubscriptionListener.onCommandSecondLevelSubscriptionError(int code, string message, string key)
        {
            Console.WriteLine("Subscription Error for " + key + ": " + message);
        }

        void SubscriptionListener.onEndOfSnapshot(string itemName, int itemPos)
        {
            Console.WriteLine("End of Snapshot for " + itemName + ".");
        }

        void SubscriptionListener.onItemLostUpdates(string itemName, int itemPos, int lostUpdates)
        {
            Console.WriteLine("Lost Updates for " + itemName + " (" + lostUpdates + ").");
        }

        void SubscriptionListener.onItemUpdate(ItemUpdate itemUpdate)
        {
            try
            {
                lock (chartForm.quotessource)
                {
                    double tmp = Double.Parse(itemUpdate.getValue("last_price"));
                    if (chartForm.quotessource.Count > 5000)
                    {
                        chartForm.quotessource.RemoveAt(0);
                    }

                    chartForm.quotessource.Add(new Record(5, itemUpdate.getValue("time"), tmp));
                    if (tmp < chartForm.minvisual) chartForm.minvisual = tmp;
                }

                chartForm.Invoke(delegateChart, new Object[] { itemUpdate.ItemPos, itemUpdate });
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }

        void SubscriptionListener.onListenEnd(Subscription subscription)
        {
            // throw new System.NotImplementedException();
        }

        void SubscriptionListener.onListenStart(Subscription subscription)
        {
            // throw new System.NotImplementedException();
        }

        void SubscriptionListener.onRealMaxFrequency(string frequency)
        {
            Console.WriteLine("Real frequency: " + frequency + ".");
        }

        void SubscriptionListener.onSubscription()
        {
            Console.WriteLine("Start subscription " + prefix);
        }

        void SubscriptionListener.onSubscriptionError(int code, string message)
        {
            Console.WriteLine("Subscription error: " + message);
        }

        void SubscriptionListener.onUnsubscription()
        {
            Console.WriteLine("Stop subscription" + prefix);
        }
    }
}