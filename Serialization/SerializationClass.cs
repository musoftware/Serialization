using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Serialization
{
    class SerializationClass
    {
        Thread mainThread;

        static object Obj = new object();

        Collection<Action> actions = new Collection<Action>();

        public void AddProcess(Action action)
        {
            actions.Add(action);
        }

        public void Run()
        {
            lock (Obj)
            {
                if (mainThread != null) return;
                mainThread = new Thread(() =>
                {
                    try
                    {
                        while (true)
                        {
                            if (actions.Count == 0) break;
                            if (actions[0] == null)
                            {
                                actions.RemoveAt(0);
                            }
                            if (actions.Count == 0) break;
                            actions[0].Invoke();
                            actions.RemoveAt(0);
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        mainThread = null;
                    }
                });
                mainThread.Start();
            }
        }


    }
}
