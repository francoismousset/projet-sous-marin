////using System;
////using System.Timers;

//namespace ISIC_SUBMARINE2010
//{
//    partial class Protocole_3964r
//    {
//        //private SousMarin parent;

//        //const byte STX = 0x02;
//        //const byte ETX = 0x03;
//        //const byte DLE = 0x10;
//        //const byte NAK = 0x15;

//        //const bool HIGH_PRIORITY = true;
//        //const bool LOW_PRIORITY = false;

//        //const int MAX_ERRORS = 6;
//        //const int NB_ERRORS = 5;

//        //const int TRANSMISSION_SUCCESS = 0;
//        //const int TRANSMISSION_FAILED = 1;

//        //const bool TRUE = false;
//        //const bool FALSE = true;

//        //bool FLAG_TIMER1;

//        //bool priority = LOW_PRIORITY;
//        //int[] tab_error_3964r = new int [NB_ERRORS];

//        public int send_data_3964r (byte[] data, byte length)
//        {
//            byte bcc, c;
//            int i = 0;
//            for (int j=0;i<5;i++)
//                tab_error_3964r[i]=0;

//            bcc = process_bcc_3964r (data, length);

//            do
//            {
//                FLAG_TIMER1 = FALSE;
//                FLAG_USART = FALSE;

//                putchar_usart (STX);

//                timer1.Start();
//                c = getchar_usart();
//                timer1.Stop();

//                if (FLAG_TIMER1 == FALSE)
//                {
//                    if (c == DLE)
//                    {

//                        for (i=0;i<length;i++)
//                        {
//                            if(FLAG_USART == FALSE)
//                            {
//                                putchar_usart (data[i]);
//                                if (data[i] == DLE) //double DLE
//                                {
//                                    if(FLAG_USART == FALSE)
//                                        putchar_usart (DLE);
//                                    else
//                                        break;
//                                }
//                            }
//                            else
//                                break;
//                        }

//                        if (FLAG_USART == FALSE)
//                        {
//                            putchar_usart (DLE);
//                            if (FLAG_USART == FALSE)
//                            {
//                                putchar_usart (ETX);
//                                if (FLAG_USART == FALSE)
//                                {

//                                    putchar_usart(bcc);
//                                    if(FLAG_USART == FALSE)
//                                    {
//                                        timer1.Start();
//                                        c=getchar_usart();
//                                        timer1.Stop();

//                                        if(FLAG_TIMER1 == FALSE)
//                                        {
//                                            if (c!=DLE)
//                                                tab_error_3964r [1] ++;
//                                        }
//                                        else
//                                            tab_error_3964r[2]++;
//                                    }
//                                    else
//                                        tab_error_3964r[3]++;
//                                }
//                                else
//                                {
//                                    tab_error_3964r[3]++;
//                                }
//                            }
//                            else
//                            {
//                                tab_error_3964r[3]++;
//                            }
//                        }
//                        else
//                        {
//                            tab_error_3964r[3]++;
//                        }
//                    }
//                    else
//                    {
//                    }
//                }
//                else
//                    tab_error_3964r[4]++;

//                if (sum_error_3964r() == MAX_ERRORS) //si somme des erreurs> seuil max
//                    return TRANSMISSION_FAILED; //retourne une erreur de transmission
//            }while((FLAG_TIMER1 == TRUE)||(FLAG_USART == TRUE));

//            return TRANSMISSION_SUCCESS;
//        }

//        //public void get_data_3964r (byte[] data)
//        //{
//        //    byte c, prev_c, bcc;
//        //    bool flag_error;
//        //    bool[] flag_dle = new bool[3];
//        //    int i;

//        //    do
//        //    {
//        //        i=0;		//initialisation des variables
//        //        prev_c=0;
//        //        FLAG_TIMER1 = FALSE;
//        //        flag_error = FALSE;
//        //        for (int j=0;i<3;i++)
//        //            flag_dle[i] = FALSE;

//        //        c = getchar_usart(); //on attend de recevoir un caractère

//        //        if(c==STX) //si reçoit un STX
//        //        {
//        //            bcc = STX;
//        //            putchar_usart (DLE); //on répond DLE

//        //            do
//        //            {
//        //                timer1.Start();
//        //                c = getchar_usart();
//        //                timer1.Stop();

//        //                if(FLAG_TIMER1 == FALSE)
//        //                {
//        //                    bcc ^= c;

//        //                    if ((prev_c != DLE) && (c == DLE))
//        //                    {
//        //                        flag_dle[0] = TRUE;
//        //                        flag_dle[1] = FALSE;
//        //                        flag_dle[2] = FALSE;
//        //                    }
//        //                    else
//        //                    {
//        //                        if ((prev_c == DLE) && (c == DLE))
//        //                        {
//        //                            if(flag_dle[1] == FALSE)
//        //                            {
//        //                                flag_dle[0] = FALSE;
//        //                                flag_dle[1] = TRUE;
//        //                                flag_dle[2] = FALSE;

//        //                                data[i] = DLE;
//        //                                i++;
//        //                            }
//        //                            else
//        //                            {
//        //                                flag_dle[0] = TRUE;
//        //                                flag_dle[1] = FALSE;
//        //                                flag_dle[2] = FALSE;
//        //                            }
//        //                        }
//        //                        else
//        //                        {
//        //                            if ((prev_c == DLE) && (c != DLE))
//        //                            {
//        //                                flag_dle[1] = FALSE;
//        //                                flag_dle[2] = TRUE;

//        //                                data[i] = c;
//        //                                i++;
//        //                            }
//        //                            else
//        //                            {
//        //                                flag_dle[0] = FALSE;
//        //                                flag_dle[1] = FALSE;
//        //                                flag_dle[2] = FALSE;

//        //                                data[i]=c;
//        //                                i++;
//        //                            }
//        //                        }
//        //                    }
//        //                    prev_c = c;
//        //                }
//        //                else
//        //                {
//        //                    putchar_usart(NAK);
//        //                    break;
//        //                }
//        //            }while (! ( (flag_dle[0] == TRUE) && (flag_dle[2] == TRUE) ) );

//        //            if(FLAG_TIMER1 == FALSE)
//        //            {
//        //                if(c == ETX)
//        //                {
//        //                    timer1.Start();
//        //                    c = getchar_usart();
//        //                    timer1.Stop();

//        //                    if(FLAG_TIMER1 == FALSE)
//        //                    {
//        //                        if (c == bcc)
//        //                            putchar_usart (DLE);
//        //                        else
//        //                        {
//        //                            putchar_usart(NAK);
//        //                            flag_error = TRUE;
//        //                        }
//        //                    }
//        //                    else
//        //                    {
//        //                        putchar_usart(NAK);
//        //                        flag_error = TRUE;
//        //                    }
//        //                }
//        //                else
//        //                {
//        //                    putchar_usart(NAK);
//        //                    flag_error = TRUE;
//        //                }
//        //            }
//        //            else
//        //            {
//        //                putchar_usart(NAK);
//        //                flag_error = TRUE;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            putchar_usart(NAK);
//        //            flag_error = TRUE;
//        //        }
//        //    }while ( (FLAG_TIMER1 == TRUE) || (flag_error == TRUE) );
//        //}

//        //public byte process_bcc_3964r (byte[] data, byte length)
//        //{
//        //    byte bcc = 0, i;

//        //    bcc ^= STX;
//        //    for(i=0;i<length;i++)
//        //    {
//        //        bcc ^= data[i];

//        //        if(data[i] == DLE) //on compte un double DLE
//        //            bcc ^= DLE;
//        //    }
//        //    bcc ^= DLE;
//        //    bcc ^= ETX;

//        //    return bcc;
//        //}

//        //public int sum_error_3964r()
//        //{
//        //    int sum, i;
//        //    for(i=0, sum=0;i<NB_ERRORS;i++)
//        //        sum += tab_error_3964r[i];
//        //    return sum;
//        //}

//        //private static System.Timers.Timer timer1;

//        //public void TIMER1()
//        //{
//        //    Timer timer1 = new System.Timers.Timer();
//        //    timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
//        //    timer1.Interval = 25;
//        //    timer1.Enabled = true;
//        //}

//        //public void OnTimedEvent(object source, ElapsedEventArgs e)
//        //{
//        //    FLAG_TIMER1 =  TRUE;
//        //}

//    }
//}


//// copie du code brut :

////using System;
////using System.Timers;

////namespace ISIC_SUBMARINE2010
////{
////    partial class Protocole_3964r
////    {
////        private SousMarin parent;

////        const byte STX = 0x02;
////        const byte ETX = 0x03;
////        const byte DLE = 0x10;
////        const byte NAK = 0x15;

////        const bool HIGH_PRIORITY = true;
////        const bool LOW_PRIORITY = false;

////        const int MAX_ERRORS = 6;
////        const int NB_ERRORS = 5;
////        //int TIMEOUT_MS = 65000 //25 ms

////        const int TRANSMISSION_SUCCESS = 0;
////        const int TRANSMISSION_FAILED = 1;
////        //int RECEPTION_MODE = 2

////        const bool TRUE = false;
////        const bool FALSE = true;

////        bool FLAG_TIMER1;

////        //void init_3964r (void);
////        //void get_data_3964r (char[]);
////        //char send_data_3964r (char[], unsigned char);

////        //char process_bcc_3964r (char[], unsigned char);

////        //char sum_error_3964r (void);

////        bool priority = LOW_PRIORITY;
////        int[] tab_error_3964r = new int [NB_ERRORS];

////        //void init_3964r (void)
////        //{
////        //    init_usart (MYUBRR);
////        //    init_timer1();
////        //    memset (tab_error_3964r, 0 , 5 );
////        //}

////        public int send_data_3964r (byte[] data, byte length)
////        {
////            byte bcc, c;
////            int i = 0;
////            //memset (tab_error_3964r , 0 , 5);
////            for (int j=0;i<5;i++)
////                tab_error_3964r[i]=0;

////            bcc = process_bcc_3964r (data, length);

////            do
////            {
////                FLAG_TIMER1 = FALSE;
////                FLAG_USART = FALSE;

////                putchar_usart (STX);

////                timer1.Start();
////                c = getchar_usart();
////                timer1.Stop();

////                if (FLAG_TIMER1 == FALSE)
////                {
////                    if (c == DLE)
////                    {
////                        //ENABLE_RX_INT_USART; //on active l'interruption de lusart en réceeption

////                        for (i=0;i<length;i++)
////                        {
////                            if(FLAG_USART == FALSE)
////                            {
////                                putchar_usart (data[i]);
////                                if (data[i] == DLE) //double DLE
////                                {
////                                    if(FLAG_USART == FALSE)
////                                        putchar_usart (DLE);
////                                    else
////                                        break;
////                                }
////                            }
////                            else
////                                break;
////                        }

////                        if (FLAG_USART == FALSE)
////                        {
////                            putchar_usart (DLE);
////                            if (FLAG_USART == FALSE)
////                            {
////                                putchar_usart (ETX);
////                                if (FLAG_USART == FALSE)
////                                {
////                                    //DISABLE_RX_INT_USART; //désactivation de l'iinterruption de réception usart

////                                    putchar_usart(bcc);
////                                    if(FLAG_USART == FALSE)
////                                    {
////                                        timer1.Start();
////                                        c=getchar_usart();
////                                        timer1.Stop();

////                                        if(FLAG_TIMER1 == FALSE)
////                                        {
////                                            if (c!=DLE)
////                                                tab_error_3964r [1] ++;
////                                        }
////                                        else
////                                            tab_error_3964r[2]++;
////                                    }
////                                    else
////                                        tab_error_3964r[3]++;
////                                }
////                                else
////                                {
////                                    //DISABLE_RX_INT_USART;
////                                    tab_error_3964r[3]++;
////                                }
////                            }
////                            else
////                            {
////                                //DISABLE_RX_INT_USART;
////                                tab_error_3964r[3]++;
////                            }
////                        }
////                        else
////                        {
////                            //DISABLE_RX_INT_USART;
////                            tab_error_3964r[3]++;
////                        }
////                    }
////                    else
////                    {
////                        //if (c==STX)
////                        //{
////                        //    if (priority = LOW_PRIORITY)
////                        //        return RECEPTION_MODE;
////                        //    else
////                        //        FLAG_TIMER1 = TRUE;
////                        //}
////                        //else
////                        //    tab_error_3964r[0]++;
////                    }
////                }
////                else
////                    tab_error_3964r[4]++;

////                if (sum_error_3964r() == MAX_ERRORS) //si somme des erreurs> seuil max
////                    return TRANSMISSION_FAILED; //retourne une erreur de transmission
////            }while((FLAG_TIMER1 == TRUE)||(FLAG_USART == TRUE));

////            return TRANSMISSION_SUCCESS;
////        }

////        public void get_data_3964r (byte[] data)
////        {
////            byte c, prev_c, bcc;
////            bool flag_error;
////            bool[] flag_dle = new bool[3];
////            int i;

////            do
////            {
////                i=0;		//initialisation des variables
////                prev_c=0;
////                FLAG_TIMER1 = FALSE;
////                flag_error = FALSE;
////                //memset (flag_dle, FALSE, 3);
////                for (int j=0;i<3;i++)
////                    flag_dle[i] = FALSE;

////                c = getchar_usart(); //on attend de recevoir un caractère

////                if(c==STX) //si reçoit un STX
////                {
////                    bcc = STX;
////                    putchar_usart (DLE); //on répond DLE

////                    do
////                    {
////                        timer1.Start();
////                        c = getchar_usart();
////                        timer1.Stop();

////                        if(FLAG_TIMER1 == FALSE)
////                        {
////                            bcc ^= c;

////                            if ((prev_c != DLE) && (c == DLE))
////                            {
////                                flag_dle[0] = TRUE;
////                                flag_dle[1] = FALSE;
////                                flag_dle[2] = FALSE;
////                            }
////                            else
////                            {
////                                if ((prev_c == DLE) && (c == DLE))
////                                {
////                                    if(flag_dle[1] == FALSE)
////                                    {
////                                        flag_dle[0] = FALSE;
////                                        flag_dle[1] = TRUE;
////                                        flag_dle[2] = FALSE;

////                                        data[i] = DLE;
////                                        i++;
////                                    }
////                                    else
////                                    {
////                                        flag_dle[0] = TRUE;
////                                        flag_dle[1] = FALSE;
////                                        flag_dle[2] = FALSE;
////                                    }
////                                }
////                                else
////                                {
////                                    if ((prev_c == DLE) && (c != DLE))
////                                    {
////                                        flag_dle[1] = FALSE;
////                                        flag_dle[2] = TRUE;

////                                        data[i] = c;
////                                        i++;
////                                    }
////                                    else
////                                    {
////                                        flag_dle[0] = FALSE;
////                                        flag_dle[1] = FALSE;
////                                        flag_dle[2] = FALSE;

////                                        data[i]=c;
////                                        i++;
////                                    }
////                                }
////                            }
////                            prev_c = c;
////                        }
////                        else
////                        {
////                            putchar_usart(NAK);
////                            break;
////                        }
////                    }while (! ( (flag_dle[0] == TRUE) && (flag_dle[2] == TRUE) ) );

////                    if(FLAG_TIMER1 == FALSE)
////                    {
////                        if(c == ETX)
////                        {
////                            timer1.Start();
////                            c = getchar_usart();
////                            timer1.Stop();

////                            if(FLAG_TIMER1 == FALSE)
////                            {
////                                if (c == bcc)
////                                    putchar_usart (DLE);
////                                else
////                                {
////                                    putchar_usart(NAK);
////                                    flag_error = TRUE;
////                                }
////                            }
////                            else
////                            {
////                                putchar_usart(NAK);
////                                flag_error = TRUE;
////                            }
////                        }
////                        else
////                        {
////                            putchar_usart(NAK);
////                            flag_error = TRUE;
////                        }
////                    }
////                    else
////                    {
////                        putchar_usart(NAK);
////                        flag_error = TRUE;
////                    }
////                }
////                else
////                {
////                    putchar_usart(NAK);
////                    flag_error = TRUE;
////                }
////            }while ( (FLAG_TIMER1 == TRUE) || (flag_error == TRUE) );
////        }

////        public byte process_bcc_3964r (byte[] data, byte length)
////        {
////            byte bcc = 0, i;

////            bcc ^= STX;
////            for(i=0;i<length;i++)
////            {
////                bcc ^= data[i];

////                if(data[i] == DLE) //on compte un double DLE
////                    bcc ^= DLE;
////            }
////            bcc ^= DLE;
////            bcc ^= ETX;

////            return bcc;
////        }

////        public int sum_error_3964r()
////        {
////            int sum, i;
////            for(i=0, sum=0;i<NB_ERRORS;i++)
////                sum += tab_error_3964r[i];
////            return sum;
////        }

////        private static System.Timers.Timer timer1;

////        public void TIMER1()
////        {
////            Timer timer1 = new System.Timers.Timer();

////            // Hook up the Elapsed event for the timer.
////            timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);

////            // Set the Interval to 25 milliseconds
////            timer1.Interval = 25;
////            timer1.Enabled = true;
////        }

////        public void OnTimedEvent(object source, ElapsedEventArgs e)
////        {
////            FLAG_TIMER1 =  TRUE;
////        }

////    }
////}