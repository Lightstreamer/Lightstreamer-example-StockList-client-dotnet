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
using System.Windows.Forms;

using Lightstreamer.DotNetStandard.Client;
using System.Threading;
using Lightstreamer.DotNet.Client.Test;

namespace DotNetStockListDemo
{
    
    class StocklistClient
    {
        private DemoForm demoForm;
        private LightstreamerUpdateDelegate updateDelegate;
        private LightstreamerStatusChangedDelegate statusChangeDelegate;

        private LSClient client;
        private ConnectionInfo cInfo;

        public StocklistClient(
                string pushServerUrl,
                DemoForm form,
                LightstreamerUpdateDelegate lsUpdateDelegate,
                LightstreamerStatusChangedDelegate lsStatusChangeDelegate)
        {
            
            demoForm = form;
            updateDelegate = lsUpdateDelegate;
            statusChangeDelegate = lsStatusChangeDelegate;

            LSClient.SetLoggerProvider(new Log4NetLoggerProviderWrapper());

            cInfo = new ConnectionInfo
            {
                PushServerUrl = pushServerUrl,
                Adapter = "WELCOME",
                ConnectTimeoutMillis = 500,
                ReadTimeoutMillis = 8000
            };

            client = new LSClient();
        }


        private int phase = 0;

        public void Start(int ph)
        {
            if (ph != this.phase)
            {
                // ignore old calls
                return;
            }
            this.Start();
        }

        public void Start()
        {
            int ph = Interlocked.Increment(ref this.phase);
            Thread t = new Thread(new ThreadStart(delegate()
            {
                Execute(ph);
            }));
            t.Start();
        }

        private void Execute(int ph) {
            if (ph != this.phase)
            {
                return;
            }
            ph = Interlocked.Increment(ref this.phase);
            this.Connect(ph);
            this.Subscribe();
        }

        public void StatusChanged(int ph, int cStatus, string status)
        {
            if (ph != this.phase)
                return;
            demoForm.Invoke(statusChangeDelegate, new Object[] { cStatus, status });
        }

        public void UpdateReceived(int ph, int itemPos, IUpdateInfo update)
        {
            if (ph != this.phase)
                return;
            demoForm.BeginInvoke(updateDelegate, new Object[] { itemPos, update });
        }
    
        private void Connect(int ph) {
            bool connected = false;
            //this method will not exit until the openConnection returns without throwing an exception
            while (!connected) {
                demoForm.Invoke(statusChangeDelegate, new Object[] { 
                    StocklistConnectionListener.VOID,
                    "Connecting to Lightstreamer Server @ " + cInfo.PushServerUrl
                });
                try {
                    if (ph != this.phase)
                        return;
                    ph = Interlocked.Increment(ref this.phase);
                    client.OpenConnection(this.cInfo, new StocklistConnectionListener(this, ph));
                    connected = true;
                } catch (PushConnException e) {
                    demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
                } catch (PushServerException e) {
                    demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
                } catch (PushUserException e) {
                    demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
                }
            
                if (!connected) {
                    Thread.Sleep(5000);
                }
                }
        }

        private void Subscribe() {
            //this method will try just one subscription.
            //we know that when this method executes we should be already connected
            //If we're not or we disconnect while subscribing we don't have to do anything here as an
            //event will be (or was) sent to the ConnectionListener that will handle the case.
            //If we're connected but the subscription fails we can't do anything as the same subscription 
            //would fail again and again (btw this should never happen)

            try
            {
                SimpleTableInfo tableInfo = new SimpleTableInfo(
                    "item1 item2 item3 item4 item5 item6 item7 item8 item9 item10 item11 item12 item13 item14 item15 item16 item17 item18 item19 item20 item21 item22 item23 item24 item25 item26 item27 item28 item29 item30",
                    "MERGE",
                    "stock_name last_price time pct_change bid_quantity bid ask ask_quantity min max ref_price open_price",
                    true)
                {
                    DataAdapter = "STOCKS"
                };

                client.SubscribeTable(
                    tableInfo,
                    new StocklistHandyTableListener(this, this.phase),
                    false);
            }
            catch (SubscrException)
            {
            }
            catch (PushServerException e)
            {
                demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
            }
            catch (PushUserException)
            {
            }
            catch (PushConnException)
            {
            }
        }

    }
}
