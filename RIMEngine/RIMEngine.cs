using System;
using System.Collections.Generic;
using System.IO;

namespace RIM
{
    class RIMEngine
    {
        //这个数据结构就是内存当中，规则的形式，就是if then 当中，if 和then 中间的前件
        //众多的前件用 next指针连接起来
        public struct CAUSE
        {
            public string Cause { get; set; }
            public CAUSE(string i) => Cause = i;
        };
        //这个数据结构就是内存当中规则库的形式，就是if then 这个规则
        //其中，result 为后件也就是结论，lastflag标记了该结论是否为最终结论，仔细阅读MarkKB函数
        //明确其值为：0/1的区别
        //cause_chain 表明了规则的前件
        //众多的规则采用next进行连接
        //这个数据结构，翻译成为规则就是： if cause_chain then result
        public struct RULE
        {
            public string Result { get; set; }
            public int Lastflag { get; set; }
            public LinkedList<CAUSE> Cause_chain { get; set; }
            public RULE(string result)
            {
                Result = result;
                Lastflag = 1;
                Cause_chain = new LinkedList<CAUSE>();
            }
            public void SetLastflag(int i) { Lastflag = i; }
        };

        LinkedList<CAUSE> DataBase;//用来存放知识库的
        LinkedList<CAUSE> Conclusion;    //这是中间推出的结论，也称综合数据库
        LinkedList<RULE> KnowledgeBase; //这个是用户录入的事实库。
        LinkedList<RULE> Used;           //这个是用户使用过的规则库列表

        public RIMEngine()
        {
            DataBase = new LinkedList<CAUSE>();
            Conclusion = new LinkedList<CAUSE>();
            KnowledgeBase = new LinkedList<RULE>();
            Used = new LinkedList<RULE>();
        }

        public void FreeDB(LinkedList<CAUSE> cause) //释放知识库，内存回收
        {
            cause.Clear();
        }
        public void FreeKB(LinkedList<RULE> rule) //释放所有的规则库列表
        {
            rule.Clear();
        }


        public int FindCause(string causeContent)          //知识库进行数据的匹配，if 和 then 中间的前件知识。
        {
            CAUSE cause = new CAUSE(causeContent);
            return DataBase.Contains(cause) || Conclusion.Contains(cause) ? 1 : 0;
        }
        public void MarkKB()                      //这个函数主要是划分中间结论和最终结论。标记isLastFlag
        {
            LinkedListNode<RULE> KBNode = KnowledgeBase.mHead;
            while (KBNode != null)
            {
                KBNode.Item.SetLastflag(1);
                KBNode = KBNode.next;
            }
            KBNode = KnowledgeBase.mHead;
            while (KBNode != null)
            {
                LinkedListNode<CAUSE> cc = KBNode.Item.Cause_chain.mHead;
                while (cc != null)
                {
                    LinkedListNode<RULE> rp = KnowledgeBase.mHead;
                    while (rp != null)
                    {
                        if (rp.Item.Result == cc.Item.Cause)
                            rp.Item.SetLastflag(0);
                        rp = rp.next;
                    }
                    cc = cc.next;
                }
                KBNode = KBNode.next;
            }

        }
        public void CreatKB()                  //创建知识库
        {
            LinkedListNode<CAUSE> cp;
            LinkedListNode<RULE> rp;
            int i, j;
            string sp;
            FreeKB(KnowledgeBase);
            FreeKB(Used);
            try
            {
                StreamReader sr = new StreamReader("rule.dat");
                //表示知识库已经存在了,可以进行数据的加载了
                while (!sr.EndOfStream)
                {
                    sp = sr.ReadLine();
                    if (sp == "" || sp == "\\") //新的规则的标记
                        break;
                    RULE nr = new RULE(sp);
                    rp = new LinkedListNode<RULE>(KnowledgeBase, nr);
                    KnowledgeBase.AddFirst(rp);
                    sp = sr.ReadLine();
                    while (sp != "\\") //表示的是前件
                    {
                        CAUSE nc = new CAUSE();
                        nc.Cause = sp;
                        cp = new LinkedListNode<CAUSE>(rp.Item.Cause_chain, nc);
                        rp.Item.Cause_chain.AddLast(cp);
                        sp = sr.ReadLine();
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.Write("\n knowledgebase is not exist,to establish!\n");
                for (i = 1; ; i++)
                {
                    Console.Write("\n********NO  " + i + "  rule********");
                    Console.Write("\n**Conclusion:(is/can/has)"); //首先输入结论
                    sp = Console.ReadLine();
                    if (sp == "")
                        break;
                    RULE nr = new RULE(sp);
                    rp = new LinkedListNode<RULE>(KnowledgeBase, nr); //创建规则链
                    KnowledgeBase.AddFirst(rp);
                    for (j = 1; ; j++)
                    {
                        Console.Write("\n***tiao(" + j + ")(is/can/has):"); //输入支持结论的前件(条件)
                        sp = Console.ReadLine();
                        if (sp == "")
                            break; //回车表示,前件录入结束
                        CAUSE nc = new CAUSE(sp);
                        cp = new LinkedListNode<CAUSE>(rp.Item.Cause_chain, nc);
                        rp.Item.Cause_chain.AddFirst(cp);
                    }
                }
                if (KnowledgeBase.mHead == null)
                {
                    Console.Write("\n There is no rule in the Knowledgebase!\n");
                    return;
                }
                //将数据保存到文件当中,一共下一次进行数据的调用
                try
                {
                    StreamWriter sw = new StreamWriter("rule.dat");
                    rp = KnowledgeBase.mHead;
                    while (rp != null)
                    {
                        sw.WriteLine(rp.Item.Result);
                        cp = rp.Item.Cause_chain.mHead;
                        while (cp != null)
                        {
                            sw.WriteLine(cp.Item.Cause);
                            cp = cp.next;
                        }
                        sw.WriteLine("\\");  //规则和规则之间用字符"\"分开
                        rp = rp.next;
                    }
                    sw.Close();
                }
                catch (IOException)
                {
                    Console.Write("\n write file is error!\n");
                    return;
                }
            }
            finally
            {
                MarkKB();
            }
        }
        public void InputDB()                 //数据事实
        {
            int i;
            string sp;
            LinkedListNode<CAUSE> cp;
            FreeDB(DataBase);
            FreeDB(Conclusion);

            Console.Write("\n*****please input the knowledge:\n");
            for (i = 1; ; i++)
            {
                Console.Write("\n**tiao jian " + i + " (is/can/has):");
                sp = Console.ReadLine();
                if (sp == "")
                    break;
                CAUSE nc = new CAUSE(sp);
                cp = new LinkedListNode<CAUSE>(DataBase, nc); //创建事实库的链表
                DataBase.AddFirst(cp);
            }
        }
        public void Think()                      //推理机进行推理
        {
            LinkedListNode<RULE> rp1, rp2;
            LinkedListNode<CAUSE> cp1;
            int RuleCount, i;
            string sp;
            //用户使用过的规则,添加到数据库当中,因为使用过的规则被裁减下来,放到used当中去了
            if (Used.mHead != null)
            {
                rp1 = Used.mHead;
                while (rp1.next!=null)
                    rp1 = rp1.next;
                rp1.next = KnowledgeBase.mHead;
                KnowledgeBase.mHead = Used.mHead;
                Used.Clear();
            }
            //将结论的表进行清空,以便于进行新的推理解释
            if (Conclusion.mHead != null)
            {
                FreeDB(Conclusion);
            }
            //正式开始进行推理了.
            do
            {
                RuleCount = 0;
                rp1 = KnowledgeBase.mHead; //通过定位两个知识的指针,来进行知识的匹配
                rp2 = KnowledgeBase.mHead;
                while (rp1 != null)
                {

                    cp1 = rp1.Item.Cause_chain.mHead; //第一个规则的前件
                    while (cp1 != null)
                    {
                        if (FindCause(cp1.Item.Cause) == 0) //找到第一个规则当中的数据是否跟用户给出的事实进行匹配,如果有不匹配的退出
                        {
                            break;
                        }
                        else
                        {
                            cp1 = cp1.next;
                        }
                    }
                    if (cp1 != null) //证明没有完全匹配的前件,所以知识库的结果下移动一个位置
                    {
                        rp2 = rp1;
                        rp1 = rp1.next;
                    }
                    else if (FindCause(rp1.Item.Result) == 0)
                    {
                        /*若该条规格的结论文新事实,将该结论加入结论链表,并将该条规则从知识库中取出,插入已经使用的规则链表中*/
                        CAUSE nc = new CAUSE(rp1.Item.Result);
                        cp1 = new LinkedListNode<CAUSE>(Conclusion, nc);
                        Conclusion.AddFirst(cp1);
                        if (rp1.Item.Result == rp2.Item.Result)
                            rp2 = rp2.next;
                        else
                            rp2.next = rp1.next;
                        Used.AddFirst(rp1);
                        rp1 = rp2;
                        RuleCount++;
                        if (Used.mHead.Item.Lastflag == 1) //若该规则为结论性规则,推理结束.
                        {
                            RuleCount = 0;
                            break;
                        }
                    }
                    else
                    {
                        rp2 = rp1;
                        rp1 = rp1.next;
                    }
                }
            } while (RuleCount > 0);
            if (Conclusion.mHead == null || Used.mHead.Item.Lastflag == 0)
            {

                Console.Write("\n know is not enough!Please add the knowledge:\n");
                Console.Write("\n*****the known knowledge:\n");
                cp1 = DataBase.mHead;
                for (i = 1; cp1 != null; i++)
                {
                    Console.Write("\n**tiao jian" + i + ":(is/can/has) " + cp1.Item.Cause);
                    cp1 = cp1.next;
                }
                Console.Write("\n*****The add knowledge:\n");
                for (; ; i++)
                {
                    Console.Write("\n**tiao jian" + i + ":(shi/can/has)");
                    sp = Console.ReadLine();
                    if (sp == "")
                        break;
                    CAUSE nc = new CAUSE(sp);
                    cp1 = new LinkedListNode<CAUSE>(DataBase, nc);
                    DataBase.AddFirst(cp1);
                }
                Think();
            }
            else
            {
                Console.Write("\n this animal is:(is/can/has)\"%s\"\n", Conclusion.mHead.Item.Cause);
            }
        }
        public void Explain()       //显示整个推理的过程
        {
            LinkedListNode<RULE> rp, rp2;
            LinkedListNode<CAUSE> cp;
            int i;
            rp = Used.mHead;
            rp2 = Used.mHead;
            i = 0;
            while (rp != null)
            {
                Console.Write("\n*this animal is(is/can/has)\"" + rp.Item.Result + "\",because:\n"); //数据相关的结论,前件在后面输出
                cp = rp.Item.Cause_chain.mHead;
                while (cp != null)
                {
                    Console.Write("**(" + (i++) + ")--it(is/can/has)\"" + cp.Item.Cause + "\"\n"); //输出相关的前件
                    cp = cp.next;
                }
                rp = rp.next;
            }
        }
    }
}

