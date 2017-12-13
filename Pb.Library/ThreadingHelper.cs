using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Pb.Library
{
    /// <summary>
    /// 多线程帮助类
    /// </summary>
    public class ThreadingHelper
    {
        #region 私有变量
        private Dictionary<int, IBaseThreading> cputhreadings;
        private Dictionary<int, Thread> threads;
        private bool ContralerLock = false;
        private bool IsSuspend = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 线程控制器
        /// </summary>
        /// <param name="threadingDic">线程任务队列</param>
        public ThreadingHelper(Dictionary<int, IBaseThreading> threadingDic)
        {
            cputhreadings = threadingDic;
        }

        /// <summary>
        /// 线程控制器
        /// </summary>
        public ThreadingHelper()
        {
            cputhreadings = new Dictionary<int, IBaseThreading>();
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 添加线程任务
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="threading">线程任务</param>
        public void Add(int id, IBaseThreading threading)
        {
            if (ContralerLock)
            {
                throw new Exception("任务已启动，不能添加！");
            }
            if (id < 0 || System.Environment.ProcessorCount <= id)
            {
                throw new Exception(string.Format("ID为{0}的不存在！", id));
            }
            if (cputhreadings.ContainsKey(id))
            {
                throw new Exception(string.Format("ID为{0}的已存在任务！", id));
            }
            cputhreadings.Add(id, threading);
        }

        /// <summary>
        /// 删除线程任务
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>被删除的任务</returns>
        public IBaseThreading Delete(int id)
        {
            if (ContralerLock)
            {
                throw new Exception("任务已启动，不能删除！");
            }
            try
            {
                IBaseThreading threading = cputhreadings[id];
                cputhreadings.Remove(id);
                return threading;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 修改线程任务
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="threading">线程任务</param>
        /// <returns>被修改的任务</returns>
        public IBaseThreading Modify(int id, IBaseThreading threading)
        {
            if (ContralerLock)
            {
                throw new Exception("任务已启动，不能修改！");
            }
            try
            {
                IBaseThreading temp = cputhreadings[id];
                cputhreadings[id] = threading;
                return temp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        public void Start()
        {
            if (!ContralerLock)
            {
                //如果线程被挂起，则重新启动
                if (IsSuspend)
                {
                    IsSuspend = false;
                    foreach (int temp in threads.Keys)
                    {
                        threads[temp].Start();
                    }
                }
                else
                {
                    ContralerLock = true;
                    //线程未初始化
                    if (threads == null)
                    {
                        threads = new Dictionary<int, Thread>();
                    }
                    //之前初始化过线程，终止之前的所有线程
                    else
                    {
                        foreach (int key in threads.Keys)
                        {
                            threads[key].Abort();
                        }
                        threads.Clear();
                    }
                    //为所有线程指定cpu，并启动
                    Process current = Process.GetCurrentProcess();
                    //初始化线程队列
                    foreach (int id in cputhreadings.Keys)
                    {
                        Thread thread = new Thread(new ThreadStart(cputhreadings[id].Start));
                        threads.Add(id, thread);
                        thread.Start();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 挂起
        /// </summary>
        public void Suspend()
        {
            if (ContralerLock)
            {
                IsSuspend=true;
                foreach (int temp in threads.Keys)
                {
                    threads[temp].Suspend();
                }
            }
        }

        /// <summary>
        /// 结束所有任务
        /// </summary>
        public void End()
        {
            foreach (int temp in threads.Keys)
            {
                threads[temp].Abort();
            }
            threads.Clear();
            cputhreadings.Clear();
            IsSuspend = false;
            ContralerLock = false;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 根据线程的唯一标志符获取该线程需要运行的CpuID
        /// </summary>
        /// <param name="managedThreadId">唯一标志符</param>
        /// <returns>CpuID</returns>
        private int GetThreadRunCpu(int managedThreadId)
        {
            foreach (int temp in threads.Keys)
            {
                if (threads[temp].ManagedThreadId == managedThreadId)
                    return temp;
            }
            return -1;
        }
        #endregion
    }
}
