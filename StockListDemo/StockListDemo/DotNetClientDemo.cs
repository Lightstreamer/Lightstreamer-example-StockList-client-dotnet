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
using System.Windows.Forms;

namespace DotNetStockListDemo
{

    static class DotNetStockListDemo
    {

        [STAThread]
        static void Main(string[] args) {
            string pushServerHost = "https://push.lightstreamer.com/";
            int pushServerPort = 0;
            string forceTransport = "no";

            if (args.Length >= 1) {
                pushServerHost = args[0];
            }
            if (args.Length >= 2) {
                pushServerPort = Int32.Parse(args[1]);
            }
            if (args.Length >= 3)
            {
                forceTransport = args[2];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DemoForm form = new DemoForm(pushServerHost, pushServerPort, forceTransport);
            Application.AddMessageFilter(form);
            Application.Run(form);
        }
    }

}