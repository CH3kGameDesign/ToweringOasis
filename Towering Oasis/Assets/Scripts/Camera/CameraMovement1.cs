﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement1 : MonoBehaviour
{

    public float m_nPanSpeed = 1;
    private Camera c_Cam;
    public float m_fCameraYmax = 2;
    public float m_fCameraYmin = -2;
    public float m_fCameraXmax = 2;
    public float m_fCameraXmin = -2;

    private Vector3 cursorPosition;
    private Vector3 cursorPositionPast;

	// Use this for initialization
	void Start ()
    {
        c_Cam = GetComponent<Camera>();
        cursorPosition = Input.mousePosition;
        cursorPositionPast = cursorPosition;
	}

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            Vector3 mouseMovement = new Vector3((cursorPosition.x - cursorPositionPast.x) * m_nPanSpeed, (cursorPosition.y - cursorPositionPast.y) * m_nPanSpeed, (cursorPosition.z - cursorPositionPast.z) * m_nPanSpeed);
            transform.localPosition = new Vector3(transform.localPosition.x - mouseMovement.x, transform.localPosition.y - mouseMovement.y, transform.localPosition.z - mouseMovement.z);
        }
        cursorPositionPast = cursorPosition;
        SetCameraBounds();
    }

    private void SetCameraBounds()
    {
        if (transform.localPosition.x > m_fCameraXmax)
        {
            transform.localPosition = new Vector3(m_fCameraXmax, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x < m_fCameraXmin)
        {
            transform.localPosition = new Vector3(m_fCameraXmin, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y > m_fCameraYmax)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, m_fCameraYmax, transform.localPosition.z);
        }
        if (transform.localPosition.y < m_fCameraYmin)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, m_fCameraYmin, transform.localPosition.z);
        }
    }
}

/*           THE
            ROOM©
  By
         Tommy P. Wiseau
             Copyright ©, 1999     Copyright ©, 2001­15
             Copyright ©, 2000     ALL RIGHT RESERVED
1.               
               This play can be played without any age restriction. It will
               work if the chemistry between all the characters makes sense. 
               Human behavior and betrayal applies to all of us. It exists 
               within ourselves. You love somebody. Do you? What is love? 
               You think you have everything, but you don't have anything. 
               You have to have hope and spirit. Be an optimist. But can you 
               handle all your human behavior or other's behavior? You don't 
               want to be good, but great. 
THE ROOM, by Tommy P. Wiseau
               ACT I
               SCENE 1 
               YOU CAN SEE THE GOLDEN GATE BRIDGE, SUNRISE BEHIND THE BAY. 
               THEN AN EXTERNAL SHOT OF AN APARTMENT BUILDING SOUTH OF 
               MARKET STREET. THERE IS A SHOT OF A WINDOW OF THE ROOM. IT IS 
               FURNISHED SIMPLY. 
               AS WE PAN ACROSS THE ROOM WE SEE A MAN AND A WOMAN ASLEEP AND 
               PARTIALLY NAKED. THE ALARM CLOCK RINGS. THE MAN REACHES TO 
               THE CLOCK AND TURNS IT OFF. HE SLEEPILY AROUSES AND PUTS ON 
               HIS SHORTS AND WALKS SLOWLY TO THE BATHROOM. HE CLOSES THE 
               DOOR. PAN BACK TO THE WOMAN WAKING UP. THE MAN COMES OUT OF 
               THE BATHROOM AND SMILES TENDERLY AT HER. 
           
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
2.               
               CONTINUED: 
                                            LISA
               I am not a slave here, am I? 
                                           JOHNNY
               Did you like last night? 
                                            LISA
               Yes, I did. 
               (PAUSE) 
               What time do you have to be there? 
                                           JOHNNY
               (HE PULLS A SUIT FROM THE CLOSET AND THROWS IT ON THE BED 
               AND STARTS DRESSING.) 
                                           JOHNNY
               Where is my coffee? 
                                            LISA
               (SHE GETS OUT OF BED AND PUTS ON A REVEALING GOWN AND GOES TO 
               THE KITCHEN.) 
               What time do you have to be there? 
                                           JOHNNY
               (HE IS YELLING.) 
               I told you many times! 9:30! I have my promotion to think 
               about. 
                                            LISA
               Promotion! Promotion! That's all I hear about. Here is your 
               coffee and English muffin and burn your mouth. 
                                           JOHNNY
               (HE SITS DOWN AT THE TABLE DRINKING AND EATING.) 
               Old man Donkey lets me know today. I have to think about our 
               future. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
3.               
               CONTINUED: (2)
                                            LISA
               Well at least I don't have a promotion to think about. 
                                           JOHNNY
               You have too much competition in the computer field. 
                                            LISA
               I can handle it. You worry about yourself. 
                                           JOHNNY
               You sound like we have separate lives. We will be married 
               next month Lisa. 
                                            LISA
               Yeah.... Yeah.... Well. 
                                           JOHNNY
               (HE STANDS UP.) 
               Thank you for breakfast. 
               (HE KISSES HER ON THE CHEEK AND LEAVES.) 
               See you later. 
                                            LISA
               (LISA WALKS TO THE PHONE AND DIALS A NUMBER.) 
               Hi mom. How are you doing? 
                               CLAUDETTE
               (CLAUDETTE IS TALKING ON THE OTHER PHONE.) 
               I'm fine. What's happening with you? 
                                            LISA
               Nothing much. 
                               CLAUDETTE
               What's wrong? Tell me. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
4.               
               CONTINUED: (3) 
                                            LISA
               I'm not feeling good today. 
                               CLAUDETTE
               Why not? 
                                            LISA
               I don't think I want to get married. 
                               CLAUDETTE
               (CLAUDETTE RAISES HER VOICE.) 
               Why not? 
                                            LISA
               I don't love him anymore. 
                               CLAUDETTE
               Why not? Tell me why. 
                                            LISA
               He's boring. 
                               CLAUDETTE
               Well you've known him for over five years. You're engaged! 
               You said you loved him. You should reconsider. He supports 
               you, he provides for you, and you can't support yourself. He 
               is a good guy and he loves you very much. His income is very 
               secure and he told me he wants to buy you a home. 
                                            LISA
               That's why he's boring. 
                               CLAUDETTE
               What are you going to do? 
                                            LISA
               Um, I don't know. I don't mind living with him. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
5.               
               CONTINUED: (4) 
                               CLAUDETTE
               You can't do that. Did you tell Johnny about it? 
                                            LISA
               No. I don't know what to do. 
                               CLAUDETTE
               He's a very nice person and you know he's getting a promotion 
               soon. He bought you a car, a ring, clothes, whatever you like 
               and now you want to dump him. It's not right. I've always 
               thought of him as my son in law. You should marry him. He 
               would be good for you. 
                                            LISA
               Oh, I guess you're right about that, mom. 
                               CLAUDETTE
               Of course I'm right my dear, I know about men. I was not born 
               yesterday. I'm glad you listen to your mother. Nobody else 
               listens to me. I work so hard and nobody appreciates it. I 
               try to tell them what they should do, but they don't listen. 
                                            LISA
               I guess I'll try. See you later, mom. 
                               CLAUDETTE
               Okay. Take care of yourself, Lisa. Bye. 
                                            LISA
               Bye mom. 
               (LISA HANGS UP AND DIALS ANOTHER NUMBER WHILE SHE'S MUNCHING 
               ON A BAGEL.) 
                                            MARK
               (MARK, 24, A YOUNG HANDSOME MAN WITH A WELL­TRIMMED BEARD, IS
               IN A CAR AS HE ANSWERS THE CALL.) 
               Hello? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
6.               
               CONTINUED: (5) 
                                            LISA
               Hey baby, how are you doing? 
                                            MARK
               Oh hi, I'm very busy. How are you doing? 
                                            LISA
               I just finished talking to my mother and she just finished 
               giving me this big lecture about how big and great Johnny is. 
                                            MARK
               We'll talk about it later. As I already told you I'm very 
               busy. 
                                            LISA
               Busy doing what? We'll talk about it now. Whenever you say 
               we'll talk about it later, we never do. I can't wait till 
               later, we have to talk right now. You owe me one anyway. 
               Remember when Johnny saved your life? Remember it was all 
               because of me telling him to do it? 
                                            MARK
               Okay you win. What do you want to talk about? 
                                            LISA
               She is a stupid, fucking bitch. She wants to control my life. 
               I will not put up with that anymore. She's not the boss of 
               me, and nobody's going to tell ME what to do! I'm going to do 
               whatever I want and that's it! What do you think I should do? 
               I need your advice. 
                                            MARK
               Why do you ask me? I mean you've been very happy with Johnny. 
               What do you want me to say? You should enjoy life. What's the 
               problem? 
                                            LISA
               Maybe you're right. Can I see you for coffee tomorrow? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
7.               
               CONTINUED: (6) 
                                            MARK
               Ok, about twelve noon? 
                                            LISA
               Okay. I will be waiting baby. Bye 
                                            MARK
               Bye. 
               (LISA FINISHES HER BAGEL AND CHANGES HER CLOTHES.) 
               END SCENE 
               SCENE 2
               LISA IS SITTING AT THE TABLE DOING HER NAILS. SHE IS WEARING 
               TIGHT JEANS, A LOW­CUT T­SHIRT AND RED SHOES WHICH MATCH HER 
               NAIL POLISH. THE DOORBELL RINGS AND LISA WALKS OVER TO THE 
               FRONT DOOR. 
                                            LISA
               Who is it? 
                                 BILLY
               Billy. 
                                            LISA
               (LISA OPENS THE FRONT DOOR. BILLY, 18, LISA'S OBNOXIOUS 
               YOUNGER BROTHER, WHO IS A HOMOSEXUAL, IS STANDING AND 
               SMILING.) 
                                            LISA
               Hey Billy, how are you doing? 
                                 BILLY
               I’m fine. What’s new? 
                                            LISA
               Actually, I’m really busy. Do you want something? 
               (BILLY BARGES IN, PUSHING PASSED LISA.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
8.               
               CONTINUED: 
                                 BILLY
               No thanks. I just want to see Johnny. You look....um, 
               beautiful, today....so, yeah can I kiss Johnny? 
                                            LISA
               You are such a little brat! 
                                 BILLY
               I’m just kidding! I love you and Johnny, but especially 
               Johnny. 
                                            LISA
               (WITH THE SIGH.) 
               Everybody loves Johnny.... Oh, ok, Johnny is going to be here 
               any minute. You can wait if you want. 
                                 BILLY
               I got to go. You’ll tell him I stopped by? 
                                            LISA
               Of course I will. 
                                 BILLY
               Bye. 
                                            LISA
               Bye Billy. 
               (BILLY EXITS THE FLAT.) 
               END SCENE 
               SCENE 3
               LISA IS SITTING ON THE COUCH READING HER BOOK AS WE HEAR THE 
               SOUND OF THE FRONT DOOR BEING UNLOCKED. JOHNNY COMES IN 
               CARRYING FLOWERS. AS HE ENTERS, LISA STANDS UP, PLACES HER 
               BOOK ON THE TABLE AND WALKS TOWARD HIM. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
9.               
               CONTINUED: 
                                           JOHNNY
               Hi babe, these are for you. 
               (JOHNNY HANDS THE FLOWERS TO LISA.) 
                                            LISA
               Oh thanks, they are beautiful. 
               (LISA KISSES JOHNNY ON THE CHEEK.) 
               Did you get your promotion, honey? 
               (SHE TAKES THE FLOWERS TO THE KITCHEN, UNWRAPS THEM AND 
               SHOVES THEM IN A VASE. JOHNNY LIES DOWN ON THE COUCH. SHE 
               BRINGS THE FLOWERS TO THE ROOM AND PLACES THEM ON THE COFFEE 
               TABLE.) 
               You didn't get it did you. 
                                           JOHNNY
               That son of a bitch told me I will get within three months. 
               It's not right. I save them bundles, they are crazy. I don't 
               think I will ever get it. They trick me, they didn't keep 
               their promise, they betray me, and I don't care anymore. 
                                            LISA
               (LISA IS SITTING IN THE CHAIR NEXT TO THE COUCH.) 
               Did you tell them how much you saved them? 
                                           JOHNNY
               Of course I did. What do you think? They already put my ideas 
               into practice. Already the bank saves tons of money. They 
               should be grateful to have someone like me who is so good at 
               doing the things I do there. Instead old man Donkey is using 
               me and I'm the fool. 
                                            LISA
               I still love you. 
                                           JOHNNY
               You're the only one who does. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
10.               
               CONTINUED: (2) 
                                            LISA
               You still have friends, I didn't get any calls today. You're 
               right, this computer business is too competitive. I called a 
               dozen of my old clients and they don't need me. 
               (PAUSE.) 
               Do you want me to order a pizza or something? 
                                           JOHNNY
               Whatever I don't care. 
                                            LISA
               What kind of topping do you want? 
                                           JOHNNY
               I don't care. 
                                            LISA
               Are you alright? What is the matter? It's just a lousy 
               promotion. 
               (SHE ORDERS PIZZA.) 
               I'll fix a cup of chocolate. That will make you feel better. 
               (SHE GOES TO THE KITCHEN AND COMES BACK WITH A CHOCOLATE AND 
               SHE SETS IT ON THE COFFEE TABLE. 
                                           JOHNNY
               (JOHNNY SITS UP.) 
               Thank you. 
                                            LISA
               (SHE GIVES HIM THE CHOCOLATE AND SITS NEXT TO HIM.) 
               I need a drink. 
                                           JOHNNY
               I don't drink, you know. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
11.               
               CONTINUED: (3) 
                                            LISA
               (SHE GOES TO THE CABINET AND POURS TWO DRINKS AND CARRIES 
               THEM BACK TO JOHNNY AND POURS HIS DRINK INTO HIS CUP OF 
               CHOCOLATE. SHE TAKES A SIP OF HER DRINK.) 
               It's good for you. Don't worry about it. 
                                           JOHNNY
               I can't drink that. You must be crazy. 
                                            LISA
               (LISA TAKES THE DRINK FROM THE TABLE AND FORCES JOHNNY TO 
               HOLD THE DRINK IN HIS HAND.) 
               If you love me, you will drink this, my darling. 
               (THE PIZZA MAN RINGS THE BELL.) 
               You are not drinking your cognac, dear. It will taste good 
               with the pizza. 
                                           JOHNNY
               (HE TAKES A SMALL SIP AND EATS PIZZA.) 
               You're right, it's good. 
                                            LISA
               I know, I am right. Don't worry about those fuckers. You are 
               a good man. Let's drink and have some fun. 
               (FADE OUT, AND FADE IN TO THE OUTSIDE OF THE APPARTMENT. 
               INSIDE THEY ARE DRINKING.) 
                                           JOHNNY
               You have nice legs. 
               (HE'S MUMBLING.) 
                                            LISA
               (LISA IS TAPPING HIS SHOULDER.) 
               You have nice pecs. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
12.               
               CONTINUED: (4) 
                                           JOHNNY
               (THEY STUMBLE TO THE BED AND FALL INTO EACH OTHER'S ARMS, 
               LAUGHING.) 
               Ha, ha. I'm tired, I'm wasted, I love you darling! 
                                            LISA
               You've never been wasted. Make love to me, Johnny. 
               (JOHNNY DOESN'T RESPOND.) 
               Come on, you owe me one. 
                                           JOHNNY
               Okay, okay. 
               (HE IS FALLING ASLEEP. LISA TURNS OFF THE LIGHT AND CRAWLS IN 
               BED BESIDE HIM AND FALLS ASLEEP.) 
               END SCENE 
               SCENE 4
               (DRESSING HERSELF IN A SEXY OUTFIT TO GET READY FOR MARK, 
               LISA PUTS ON JEWELED SANDALS TO SHOW OFF HER TOENAILS. THE 
               DOORBELL RINGS AND SHE OPENS THE DOOR.) 
                                            MARK
               Hi. 
                                            LISA
               Hi. 
                                            MARK
               How are you doing? 
                                            LISA
               I'm fine. 
                                            MARK
               That's good. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
13.               
               CONTINUED: 
                                            LISA
               Thanks. How are you? 
                                            MARK
               Not bad. 
                                            LISA
               I'm glad. Would you like to come in? 
                                            MARK
               May I? 
                                            LISA
               Of course, come in.  You want a cup of coffee? 
                                            MARK
               Okay....... 
                                            LISA
               Have a seat. 
               (LISA GOES TO THE KITCHEN. MARK SITS DOWN AND PICKS UP A 
               SPIDER­MAN COMIC. LISA COMES BACK WITH TWO CUPS OF COFFEE AND 
               PLACES THEM ON THE TABLE.) 
                                            MARK
               Thank you. You look very nice today. 
                                            LISA
               Oh, thank you Mark. 
               (SHE GOES TO THE STEREO AND PUTS ON A CD OF CLASSICAL MUSIC 
               AND LIGHTS THE CANDLES WHICH ARE ON THE TABLE. SHE IS 
               SPEAKING IN A SEDUCTIVE VOICE.) 
               It's hot in here today, my dear boy. 
               (SHE REMOVES HER T­SHIRT AND REVEALS A TIGHT DRESS WITH FAIR 
               SHOULDERS.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
14.               
               CONTINUED: (2) 
                                            MARK
               The candles, the music, the sexy dress. What's going on here? 
                                            LISA
               (SHE MOVES CLOSER TO MARK AND SLIGHTLY TOUCHES HIM AND KISSES 
               HIM ON THE CHEEK.) 
               I like you very much lover boy. 
                                            MARK
               What are you doing this for? 
                                            LISA
               You don't like me? I'm your girl. 
                                            MARK
               (MARK LIGHTLY PUSHES LISA AWAY.) 
               Johnny's my best friend. You're going to get married next 
               month. 
                                            LISA
               (LISA PUTS THE GLASS ON THE TABLE AND APPROACHES MARK.) 
               Forget about Johnny. This is between you and me. 
               (LISA CONTINUES TO SEDUCE MARK AS HE RESISTS.) 
                                            MARK
               (HE STARTS TO GET UP.) 
               I don't think so. I'm leaving now. 
                                            LISA
               (SHE GRABS HIM IN A TIGHT HUG AND STARTS TO CRY.) 
               Don't leave. I need you, I love you. Everything is going 
               wrong. I don't want to get married. I don't love Johnny 
               anymore. I dream about you. I want you to make love to me. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
15.               
               CONTINUED: (3) 
                                            MARK
               I don't think so. Don't worry, everything is going to be 
               okay. 
               (HE GRABS HER WRIST AND PULLS HER ARMS AWAY FROM HIM. SHE 
               BREAKS FREE FROM HIS GRIP AND GRABS HIS SHIRT, PULLING IT UP 
               FROM HIS PANTS AND UNBUCKLES HIS BELT. AT THE SAME TIME SHE 
               KISSES HIM TENDERLY. HE KISSES HER BACK. SHE PULLS HIM TO THE 
               BED AND THEY LIE DOWN TOGETHER. AFTER THEY FINISH DOING SEX 
               MARK STANDS UP AND PUTS ON HIS CLOTHES IN A HURRY. AT THE 
               SAME TIME HE IS TALKING.) 
               Why did you do this to me? Why? Why? Why? 
               (HE IS YELLING.) 
               I can't believe I let you do this to me! Oh god, Johnny's my 
               best friend. 
                                            LISA
               Didn't you like it? Didn't you enjoy it? 
                                            MARK
               That's not the point. Do you realize what we've done?
                                            LISA
               I love you Mark. I love you very much. 
                                            MARK
               I was always attracted to you. I mean you are very beautiful. 
               But, listen to me Lisa, we can't do this anymore. I can't 
               hurt Johnny. 
                                            LISA
               (SARCASTICALLY.) 
               Yeah, I know. He's your best friend. 
                                            MARK
               I'm glad you understand the situation I'm in. This will be 
               our secret. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
16.               
               CONTINUED: (4) 
                                            LISA
               Did you like it? 
                                            MARK
               (NODDING HIS HEAD.) 
               Yeah. 
                                            LISA
               I knew it! 
                                            MARK
               (HE IS KISSING LISA ON THE CHEEK.) 
               See you later alligator. I have to go now. 
                                            LISA
               Okay, I'll see you later. 
               (SHE HOLDS ONTO HIS ARMS AND HE GOES OUT THE DOOR.) 
               END SCENE 
               SCENE 5
                                            LISA
               (SMILING, SHE VERY QUICKLY STRAIGHTENS THE BED. THEN SHE 
               WASHES THE COFFEE CUPS, PUTS THE CANDLES AWAY AND CHANGES TO 
               JEANS AND T­SHIRT. SHE PUTS PASTA IN THE OVEN. AND SETTLES IN 
               THE CHAIR WITH A MAGAZINE. SHORTLY THERE IS THE SOUND OF A 
               KEY IN THE DOOR. JOHNNY ENTERS THE APARTMENT WITH ONE RED 
               ROSE.) 
                                           JOHNNY
               Hi, how are you? 
                                           JOHNNY
               (HE GIVES LISA THE ROSE, TAKES HIS BLAZER OFF AND SITS DOWN 
               ON THE COUCH.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
17.               
               CONTINUED: 
                                            LISA
               (SHE SMILING AND PUTTING THE ROSE TO HER NOSE.) 
               Thank you, I'm doing great. You're so charming, you always 
               give me flowers. You're so unique. Let me kiss you. 
               (SHE GETS UP AND KISSES JOHNNY ON THE CHEEK.) 
                                           JOHNNY
               Oh, thank you. What's cooking? 
                                            LISA
               Pasta, your favorite dish, my sweet pie. 
                                           JOHNNY
               You're awfully happy today. What's up? Did you get a client? 
                                            LISA
               I called dozens of clients. No one needs my service. It's 
               very tough. Do you feel like eating now? 
                                           JOHNNY
               I'm starving. What else did you do today? You're in a very 
               good mood. 
                                            LISA
               Let me fix the pasta. 
                                           JOHNNY
               I'll take a shower. 
               (JOHNNY DISAPPEARS INTO THE BATHROOM.) 
                                            LISA
               (WHEN HE DISAPPEARS, LISA WAITS UNTIL THE WATER IS RUNNING  
               AND DIALS A NUMBER ON THE PHONE.) 
               Hi Mark, I miss you. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
18.               
               CONTINUED: (2) 
                                            MARK
               I just saw you. What are you talking about? 
                                            LISA
               Sorry my darling. I just wanted to hear your sexy voice. I 
               can tell you something now. I like how you put our sexy hands 
               around my body. You excite me so, and I love you. 
                                            MARK
               Is Johnny there? 
                                            LISA
               Yeah he's in the shower, but I like you better. 
                                            MARK
               But I don't understand you. Why do you do that? 
                                            LISA
               Because I love you. 
               (SARCASTICALLY.) 
               You don't care, do you. 
                                            MARK
               Yes I do care, but we agreed that it's over between us. 
                                            LISA
               I understand. I'm with you, it's our secret. I still have 
               feelings for you, but I guess you don't care. 
                                            MARK
               Yes, I do care. Don't drive yourself crazy. 
                                            LISA
               (THE WATER STOPS RUNNING.) 
               I have to go now. See you later my darling. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
19.               
               CONTINUED: (3) 
                                            MARK
               Don't call me that. 
                                            LISA
               Okay bye. 
                                            MARK
               Bye. 
                                           JOHNNY
               (JOHNNY COMES OUT OF THE BATHROOM WITH A TOWEL AROUND HIS 
               MIDDLE AND GOES TO THE CLOSET.) 
               Who were you talking to? 
                                            LISA
               My mother. 
                                           JOHNNY
               Is she okay? 
                                            LISA
               Oh, she tested for breast cancer, now she's talking about 
               dying. 
                                           JOHNNY
               It's no big deal these days, is it? 
                                            LISA
               No, I'm not worried. 
               (SHE IS PREPARING DINNER AND PUTTING EVERYTHING ON THE 
               TABLE.) 
               Dinner is ready. 
               (THEY SIT DOWN TO EAT.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
20.               
               CONTINUED: (4) 
                                           JOHNNY
               What happened last night? I don't remember anything. Did we 
               make love? 
                                            LISA
               You don't remember? You poor little thing. You don't remember 
               when you hit me? 
                                           JOHNNY
               (JOHNNY IS YELLING) 
               Hit you! I never would do that, even if I was drunk! You must 
               be kidding. It's not true, is it? Do you have a bruise? 
                                            LISA
               Yes, it's true. 
                                           JOHNNY
               (THEY ARE EATING.) 
               I will never drink again. I feel sick. I can't eat any more. 
               (HE IS PUSHING HIS PLATE AWAY.) 
                                            LISA
               I'm strong. Don't worry about it. I need some money. I have 
               to buy a new dress. 
                                           JOHNNY
               How much do you want? 
                                            LISA
               Around $ 300.00 
                                           JOHNNY
               Oh wow. Why so much? 
               (HE PULLS OUT HIS WALLET AND HANDS HER THREE ONE­HUNDRED 
               DOLLARS BILLS.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
21.               
               CONTINUED: (5) 
                                            LISA
               Thank you Johnny. 
               (SHE KISSES HIM ON HIS CHEEK.) 
               You're always so generous with me. 
                                           JOHNNY
               I have to be. You're my future wife. We will be married soon. 
               You love me, don't you? 
                                            LISA
               Of course I do. 
               (LISA GETS UP, CLEARS THE TABLE, AND CHANGES HER CLOTHES.) 
                                           JOHNNY
               I'm going to the roof to straighten out my head. 
                                            LISA
               Why, is it crooked? 
JOHNNY/LISA
               Ha, ha, ha, ha, ha. 
                                            LISA
               But are you okay? 
                                           JOHNNY
               I'm fine. 
                                            LISA
               Don't worry about it. 
               END SCENE 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
22.               
               SCENE 6
                                           JOHNNY
               (JOHNNY STORMS ONTO THE ROOF WITH A WATER BOTTLE AND LOOKS 
               CONFUSED AND LOST. HE SLAMS THE DOOR BEHIND HIM.) 
               I did not hit her. It's not true! It's bullshit, I did not 
               hit her. Why did Lisa say that? I would never do that! 
               (JOHNNY THROWS THE BOTTLE OF WATER TO THE GROUND.) 
               I did not hit her! 
               (JOHNNY PICKS UP A FOOTBALL FROM THE FLOOR AND TOSSES IT IN 
               THE AIR.) 
               Oh hi Mark. What's up with you? 
                                            MARK
               Not much. I'm just sitting up here thinking about life. I 
               wonder if girls like to cheat like guys do? 
                                           JOHNNY
               What makes you say that? 
                                            MARK
               (MARK STANDS UP AND JOHNNY TOSSES THE BALL TO HIM.) 
               Well, I'm just thinking, you know. 
                                           JOHNNY
               (THEY CONTINUE TO TOSS THE BALL WHILE THEY ARE TALKING.) 
               I don't have to worry about that because Lisa is loyal to me. 
                                            MARK
               You never know. People are very strange this days. I used to 
               know a girl who had a dozen guys. One of them found out about 
               it, beat her up and she ended up in a hospital. 
                                           JOHNNY
               What a story! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
23.               
               CONTINUED: 
                                            MARK
               You can say that again. 
                                           JOHNNY
               (JOHNNY GETS UP AND WALKS OVER TO MARK AND STANDS NEXT TO 
               MARK.) 
               I'm so lucky I have you as my best friend and I love Lisa so 
               much. 
                                            MARK
               Yeah man, you are lucky. 
               (PAUSE.) 
               (MARK IS SPEAKING SLOWLY, IN A LOW VOICE.) 
               Very....lucky. 
                                           JOHNNY
               You should have a girl Mark. 
                                            MARK
               (MARK WALKS AWAY FROM JOHNNY AND CAREFULLY POSITIONS HIMSELF 
               SO HE IS STANDING IN THE EXACT MIDDLE OF THE ROOF.) 
               Yeah, I guess you're right. Maybe I have one already. I don't 
               know yet. 
                                           JOHNNY
               Well what happened to that girl? Remember? Betty? That's her 
               name, isn't it? Betty? 
                                            MARK
               Yeah. 
               (PAUSE.) 
               Yeah, we don't see each other anymore. Besides she wasn't any 
               good in bed. She was beautiful, but we had too many 
               arguments. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
24.               
               CONTINUED: (2) 
                                           JOHNNY
               That's too bad. My Lisa is great when I can get it. 
                                            MARK
               (NOT BREAKING HIS GAZE FROM JOHNNY, MARK SLOWLY BACKS AWAY 
               FROM THE MIDDLE OF THE ROOF AND STARTS FEELING FOR HIS CHAIR 
               WITH HIS HAND BEHIND HIM. WHEN HE FINDS IT HE SITS DOWN.) 
               I just can't figure women out. Sometimes they're smart, 
               sometimes they're dumb. Sometimes they're good, sometimes 
               they're bad. Sometimes they're nice, sometimes they're not 
               nice. They are evil, seductive and hostile. 
                                           JOHNNY
               (JOHNNY WALKS OVER TO MARK.) 
                                           JOHNNY
               Seems to me like you're an expert on this. 
               (JOHNNY SITS DOWN NEXT TO MARK.) 
                                            MARK
               (LAUGHING BITTERLY.) 
               Nooooo. I'm definitely not an expert. 
                                           JOHNNY
               What's bothering you Mark? 
                                            MARK
               (MARK STANDS UP AND SHOUTS.) 
               Nothing man! Forget it! 
                                           JOHNNY
               (JOHNNY GETS UP AND GOES AFTER MARK.) 
               Is it some secrets Mark? Why don't you tell me? We are like 
               brothers, we shouldn't have secrets. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
25.               
               CONTINUED: (3) 
                                            MARK
               No forget it, I'll talk to you later! 
               (MARK GOES THROUGH THE DOOR. JOHNNY GOES AND LIES FACE DOWN 
               ON THE BENCH, CLUTCHING THE FOOTBALL TIGHTLY AT HIS SIDE.) 
               END SCENE 
               SCENE 7
               LISA IS SITTING UNDERNEATH THE STAIRCASE WITH A CLIPBOARD AND 
               DISCUSSING JOHNNY'S BIRTHDAY PARTY WITH HER MOTHER CLAUDETTE. 
               CLAUDETTE AND LISA ARE DRINKING TEA. 
                                            LISA
               So, I'm organizing a party for Johnny's birthday. Can you 
               come? 
                               CLAUDETTE
               When is it? 
                                            LISA
               Next Friday at six. It's a surprise. You can bring someone if 
               you want. 
                               CLAUDETTE
               Well, sure, I can come, but I don't know if I'll bring 
               anybody. Oh that jerk Harold, he wants me to give him a share 
               of my house. That house belongs to me, he has no right. I'm 
               not giving him a penny. Who does he think he is? 
                                            LISA
               He's your brother. 
                               CLAUDETTE
               He is always bugging me about my house. Fifteen years ago we 
               agreed that house belongs to me. Now the value of the house 
               is going up and he's seeing dollar signs. Everything goes 
               wrong at once. Nobody wants to help me and I'm dying. 
                                            LISA
               We already discussed this. You're not dying mom. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
26.               
               CONTINUED: 
                               CLAUDETTE
               I am Lisa. I finally got the results of the test back. I 
               definitely have breast cancer. 
                                            LISA
               Look, don't worry about it, everything will be fine. They are 
               curing lots of people everyday and Johnny says it's not a big 
               deal anymore. 
                               CLAUDETTE
               I'm sure he's right. I'll be fine. Oh I heard Edward is 
               talking about me. He is a hateful man. I'm so glad I divorced 
               him. I really think he gave me the breast cancer after he 
               slept with that hooker. That type of riffraff carry all sorts 
               of things. Don't you agree? 
                                            LISA
               Look, don't worry about it. You just concentrate on getting 
               well. 
                               CLAUDETTE
               Well at least you have a good man. 
                                            LISA
               You're wrong, mom. He's not what you think he is. He didn't 
               get his promotion, and he got drunk last night and he hit me. 
                               CLAUDETTE
               Johhny doesn't drink. What are you talking about? 
                                            LISA
               He did last night, and I don't love him anymore. 
                               CLAUDETTE
               Johnny is your financial security. You can't afford to ignore 
               this. 
                                            LISA
               Yeah, ok mom. Can I just talk to you later? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
27.               
               CONTINUED: (2) 
                               CLAUDETTE
               You don't want to talk to me. 
                                            LISA
               I just got done talking with a client and I have to get ready 
               to meet him. Can I just talk to you later? 
                               CLAUDETTE
               Ok, I will see you later. Bye, bye. 
               (CLAUDETTE GETS UP FROM THE ARMCHAIR AND TAPS LISA ON THE 
               NOSE. SHE THEN EXITS AS WE SEE LISA WATCH HER. LISA IS UNDER 
               THE STAIRCASE.) 
               END SCENE 
               ACT II
               SCENE 8
               MICHELLE, A PRETTY BLOND CARRYING A BOOK, AND BRAN, A YOUNG 
               BLOND MAN CARRYING A BOX OF CHOCOLATES, BOTH GOOD FRIENDS OF 
               LISA AND JOHNNY, SECRETLY ENTER THE ROOM, MAKING SURE THEY 
               ARE NOT SEEN. BRAN CLOSES THE DOOR BEHIND THEM AND THEY COME 
               TOGETHER. 
                                          MICHELLE
               How much time do we have? 
                                            BRAN
               I don't know. A couple of hours at least. 
                                          MICHELLE
               (MICHELLE LEADS BRAN TO THE COUCH AND THEY SIT DOWN 
               TOGETHER.) 
               Let's have some fun. 
                                            BRAN
               (BRAN OPENS THE BOX OF CHOCOLATES AND PICKS A PIECE OUT.) 
               Did you know that chocolate is the symbol of love? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
28.               
               CONTINUED: 
                                          MICHELLE
               Feed me. 
               (BRAN PUTS THE CHOCOLATE IN HER MOUTH.) 
               Yum. 
               (BRAN AND MICHELLE BEGIN KISSING PASSIONATELY. BRAN THEN 
               TAKES ANOTHER CHOCOLATE AND PLACES IT ON MICHELLE'S CHEST AND 
               EATS IT OFF HER CHEST. HE STARTS KISSING HER NECK AS WELL.) 
                                            BRAN
               It's delicious, just like your neck. 
               (BRAN LEANS BACK AND MICHELLE SITS UP.) 
                                          MICHELLE
               Arm's up. 
               (MICHELLE TAKES BRAN'S SWEATER OFF AND PUSHES HIM BACK ONTO 
               THE COUCH SO THAT BRAN IS LYING DOWN. MICHELLE THEN TAKES A 
               CHOCOLATE OUT OF THE BOX.) 
               Chocolate is the symbol of love. 
               (MICHELLE THEN PLACES THE CHOCOLATE IN HIS MOUTH AND ENJOYS 
               HIS BODY AS THE LIGHTING FADES TO BLACK.) 
               END SCENE 
               SCENE 9
               MICHELLE AND BRAN JUMP UP FROM THE COUCH AS THEY SEE LISA AND 
               CLAUDETTE ARRIVE FROM SHOPPING WITH BAGS. LISA AND CLAUDETTE 
               ARE SHOCKED TO SEE THEM. 
                               CLAUDETTE
               Hello.... 
               (BRAN ADJUSTS HIS SWEATER AS MICHELLE LOOKS SHOCKED.) 
                               CLAUDETTE
               What are these characters doing here? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
29.               
               CONTINUED: 
                                            LISA
               They like to come here to do their homework. 
                               CLAUDETTE
               What homework! 
                                            BRAN
               It's in Michelle's purse. 
                                            LISA
               Mom, this is Michelle's boyfriend Bran. Bran, this is my 
               mother. 
                                            BRAN
               It's a pleasure to meet you. 
               (BRAN TRIES TO SHAKE CLAUDETTE'S HAND BUT SHE JUST LOOKS 
               AWAY.) 
                                          MICHELLE
               Uh, huh. 
               (MICHELLE AND BRAN EXIT AS CLAUDETTE IS DUMBFOUNDED.) 
                               CLAUDETTE
               (CLAUDETTE WALKS OVER AND SITS ON THE COUCH.) 
               All that shopping wore me out. 
                                 BILLY
               (BILLY STORMS INTO THE FLAT.) 
               Hey Lisa. 
               (He spots Claudette.) 
               Oh, hello....mother. What a pleasant surprise to see you 
               here. 
                               CLAUDETTE
               Well, well. If it isn't my son, the homo. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
30.               
               CONTINUED: (2) 
                                 BILLY
               I just need to borrow some sugar. 
                                            LISA
               Help yourself Billy. 
                                 BILLY
               I also need a cup of flour and half a stick of butter. 
                               CLAUDETTE
               Just what sort of perverted filth are you planning to use 
               those ingredients for!? 
                                 BILLY
               I'll come back later. 
               (BILLY EXITS THE FLAT. LISA GOES OVER AND SITS DOWN NEXT TO 
               HER MOTHER.) 
                               CLAUDETTE
               Tell me, what does Billy do for money? You're not lending him 
               any I hope. 
                                            LISA
               Johnny wanted to adopt Billy after you disowned him. It's 
               really a tragedy how many kids out there don't have a great 
               friend like Johnny. When Billy turned eighteen, Johnny found 
               him a little apartment here in this building and he is paying 
               for it until he graduates from school. Johnny is very caring 
               about the people in his life, and he gave Billy his own set 
               of keys to our place. Billy has a thing for Johnny, but I 
               don't like it, so we try to discourage it. 
                               CLAUDETTE
               That boy has been nothing but trouble. First the cesarean and 
               now this. It's time Billy grew up and took care of himself. 
                                            LISA
               Johnny really cares about Billy, but Billy is so annoying. 
               That's another reason why I don't love Johnny anymore. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
31.               
               CONTINUED: (3) 
                               CLAUDETTE
               Johnny makes a lot of money, so please don't hurt him. Now If 
               you really don't love Johnny so be it, but you should wait 
               till after you're married before you tell him. That way he 
               has to split his assets with you 50/50 if he wants a divorce. 
                                            BRAN
               (BRAN COMES RUSHING THROUGH THE FRONT DOOR AND RIGHT TO THE 
               COUCH. HE REACHES UNDER THE SEAT LOOKING FOR SOMETHING.) 
               I forgot my book. 
               (BRAN GRABS HIS UNDERWEAR AND CLAUDETTE GRABS IT FROM HIM.) 
                               CLAUDETTE
               Some book! What's it called, "The Week Bran Forgot To Change 
               His Underwear"? 
                                            BRAN
               Oh, that's nothing. 
               (BRAN GRABS HIS UNDERWEAR BACK AND STORMS OUT, CLOSING THE 
               DOOR. LISA AND CLAUDETTE CACKLE HYSTERICALLY.) 
                               CLAUDETTE
               Homework? 
                                            LISA
               Don't worry about it. 
                               CLAUDETTE
               If I were a burglar, you would be my best friend. 
                                            LISA
               Look, I don't want to talk about it. 
                               CLAUDETTE
               You know, I worry about you. I have to go home. Don't you 
               ever have sex with that Bran character. Homework indeed. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
32.               
               CONTINUED: (4) 
                                            LISA
               Ok, mom. 
                               CLAUDETTE
               Bye, bye. 
               (CLAUDETTE TAPS LISA ON THE NOSE. CLAUDETTE LEAVES THE FLAT. 
               LISA LEANS BACK ON THE COUCH.) 
                                            LISA
               I need a drink. 
               END SCENE 
               SCENE 10
               BILLY IS DRIBBLING THE FOOTBALL AS JIMMY, A RUGGED DRUG 
               DEALING PIMP WITH CHISELED FEATURES AND A BLACK BEANIE, 
               ENTERS ONTO THE ROOF. 
                                 JIMMY
               Hey Billy. 
                                 BILLY
               Jimmy! I've been looking for you. 
                                 JIMMY
               Yeah, sure you have. You have my money right. 
               (BIMMY AND JIMMY ARE PASSING THE BALL BACK AND FORTH.) 
                                 BILLY
               Yeah it's coming. It'll be here in a few minutes. 
                                 JIMMY
               What do you mean it's coming Billy? Where's my money? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
33.               
               CONTINUED: 
                                 BILLY
               (SARCASTICALLY.) 
               Okay, chill out there Gramaha, Supreme Leader of the Astra 
               Galactic Command. Just hold your wiener for five minutes and 
               relax. The cash is on its way. 
                                 JIMMY
               Five minutes? You want five fucking minutes. You know what... 
               (JIMMY REMOVES A GUN FROM HIS BACK POCKET AND PUTS IT TO 
               BILLY'S HEAD AS HE PUTS BILLY ON HIS KNEES.) 
               I haven't got five fucking minutes! I'm going to ask you only 
               one more time, so you better answer right. Where's my money 
               Billy? 
                                 BILLY
               Bite me! 
                                 JIMMY
               Where's my money Billy? Where's my fucking money Billy? What 
               did you do with my fucking money, you homo? 
                                 BILLY
               It's coming! It's coming! 
                                 JIMMY
               Where's my fucking money Billy? 
                                 BILLY
               Put the gun down! 
                                 JIMMY
               (SARCASTICALLY.) 
               What's the matter Billy, do guns scare you? 
                                 BILLY
               Guns don't scare me. Idiots with guns scare me. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
34.               
               CONTINUED: (2) 
                                 JIMMY
               That's it! Where's my fucking money Billy!? 
               (MARK, LISA AND CLAUDETTE ENTER THE ROOF AND JIMMY POINTS THE 
               GUN AT THEM. JIMMY YELLS.) 
               Over there! All of you, over there! NOW! 
               (JIMMY MOTIONS WITH THE GUN TOWARD THE SIDE OF THE ROOF. 
               BILLY, MARK, LISA AND CLAUDETTE MOVE THERE WHILE JIMMY HOLDS 
               THEM AT GUNPOINT.) 
                                 JIMMY
               Say your prayers wienerheads, because I'm about to make some 
               Swiss cheese.....out of YOU! 
               (AT THAT MOMENT THE VIEW CHANGES TO JIMMY'S PERSPECTIVE AS 
               OMINOUS OPERA MUSIC, SUCH AS CARL ORFF'S "O FORTUNA", OR 
               EQUIVALENT STARTS TO PLAY. JOHNNY'S MERCEDEZ IS SEEN RISING 
               SLOWLY OVER THE EDGE OF THE ROOF WITH JOHNNY AT THE WHEELE. 
               AS HE HOVERS IN THE AIR IN FRONT AND ABOVE THE GROUP, THE 
               MUSIC SUBSIDES. JOHNNY SMILES, REVEALING LONG FANGED TEETH. 
               HE IS GLOWING.) 
                                           JOHNNY
               Do you know who I am? I have 9 black belts, 15 Master's 
               degrees and a PhD in Agricultural Economics. That's right, 
               you know I'm way better than you, and all my friends will 
               gladly tell you just how great and awesome I am! Have you 
               seen my power level? It's over 9,000! You know what that 
               means? It means I have more than 9,000 units of POWER. It 
               also puts my total adjusted force rating at 22,000! That's 
               more than triple, so you don't want to make me mad, because 
               anger is my middle name! 
                                 JIMMY
               (TREMBLING WITH FEAR JIMMY MANAGES TO RAISE THE GUN AND AIM 
               IT AT JOHNNY. HE FIRES SOME SHOTS, BUT JOHNNY EXTENDS HIS 
               HAND OUT THE DRIVER'S SIDE WINDOW AND DEFLECTS THE BULLETS. 
               NEXT JOHNNY EMITS A POWER FIELD FROM HIS HAND WHICH 
               ENCOMPASSES JIMMY. JIMMY THRUSTS HIS ARMS OUT TO HIS SIDES 
               AND YELLS.) 
                                 JIMMY
               Don't touch Jimmy!!! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
35.               
               CONTINUED: (3) 
               (JOHNNY USES THE FIELD TO LEVITATE JIMMY, HOLDING HIM HIGH IN 
               THE AIR UNTIL JIMMY DROPS THE GUN. A REAR PASSENGER DOOR 
               OPENS AS JOHNNY DRAWS JIMMY TOWARD THE CAR AND DROPS HIM IN 
               THE BACK SEAT. JOHNNY WAVES TO THE GROUP. THE GROUP WAVES 
               BACK AS JOHNNY AND HIS CAPTIVE FLY OFF OVER THE SKYLINE, THEN 
               UPWARDS, DISAPPEARING OUT OF SIGHT.) 
                                            LISA
               (LISA AND CLAUDETTE APPROACH BILLY WHO IS AT THE EDGE OF THE 
               ROOF IN A HYSTERICAL STATE. MARK IS SHAKEN AND SPEECHLESS, 
               AND WATCHES FROM THE OTHER SIDE OF THE ROOF.) 
                                            LISA
               Billy....are you okay? What did that man want from you? 
                                 BILLY
               Nothing! 
                               CLAUDETTE
               That was not nothing! 
                                            LISA
               Tell me everything! 
                               CLAUDETTE
               You have no idea what kind of trouble you are in here, do 
               you!? 
                                 BILLY
               I owe him some money. 
                                            LISA
               What kind of money? 
                                 BILLY
               I owe him some money. 
                                            LISA
               What kind of money? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
36.               
               CONTINUED: (4) 
                                 BILLY
               Everything is okay, he's gone! 
                               CLAUDETTE
               Everything is not okay. That is a dangerous man. 
                                 BILLY
               Calm down. Johnny's taking him to jail! 
                                            LISA
               Billy, what kind of money? Just tell me! 
                               CLAUDETTE
               What do you need money for? 
                                            LISA
               Mom please! Billy is with me and Johnny! 
                               CLAUDETTE
               A man like that with a gun! Oh my god! 
                                            LISA
               Billy, look at me in the eyes and tell me the truth. We're 
               your friends. 
                                 BILLY
               I've been prostituting myself to make some money, and he's my 
               pimp. Things got mixed up. He thinks I'm holding out on him. 
               I didn't mean for this to happen. 
                                            LISA
               (LISA STARTS CRYING.) 
               Billy....Billy. 
                                 BILLY
               I don't work for him anymore. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
37.               
               CONTINUED: (5) 
                                            LISA
               Your clients, were they johns or tricks, Billy!? 
                                 BILLY
               It doesn't matter. I don't do it anymore. 
                               CLAUDETTE
               It doesn't matter!? How the hell did you get involved with 
               prostitution!? Are you taking drugs? 
                                            LISA
               Mom. 
                               CLAUDETTE
               What, were you a hooker, call boy, a kerb crawler? Where in 
               the hell did you meet that man!? 
                                            LISA
               Were your clients johns or tricks? 
                                 BILLY
               They're the same thing, and kerb crawlers are johns! 
               (HE THINKS.) 
               ....also tricks. 
                                            LISA
               (LISA GRABS BILLY AND SHAKES HIM) 
               What the hell is wrong with you!! 
                                 BILLY
               I just needed some money to pay off some stuff. 
                                            LISA
               How much do you have to give him!? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
38.               
               CONTINUED: (6) 
                               CLAUDETTE
               This is not the way you make money young man. 
                                            LISA
               How much!? 
                                 BILLY
               Stop ganging up on me! 
                               CLAUDETTE
               Well it is time somebody ganged you for god's sake. A man 
               like that. Where the hell did you meet a man like that!? 
                                 BILLY
               It doesn't matter! 
                               CLAUDETTE
               It matters a great deal! A man holds a gun on you. You almost 
               got killed! You expect me to forget that happened? 
                                 BILLY
               You are not my fucking mother anymore! 
                               CLAUDETTE
               (CLAUDETTE GRABS BILLY BY THE NOSE AND YANKS HIM TOWARDS 
               HER.) 
               That's why I'm going to enjoy this so much! Pull down your 
               pants, boy. It's time you got a belt whipping! 
                                            LISA
               (LISA INTERFERES AND PULLS BILLY AWAY FROM CLAUDETTE.) 
               No, no! 
                               CLAUDETTE
               Somebody had better do something around here! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
39.               
               CONTINUED: (7) 
                                            LISA
               (LISA CONSOLES AND CARESSES BILLY AS HE CRIES.) 
               It's okay, it's okay. 
                                           JOHNNY
               (JOHNNY REENTERS ONTO THE ROOF WITH A TRICKLE OF BLOOD ON THE 
               SIDE OF HIS MOUTH. HE HEADS TOWARD BILLY.) 
               Are you okay Billy? 
                                 BILLY
               I'm okay. 
                                           JOHNNY
               Are you really okay? 
                                 BILLY
               I'm okay. 
                                           JOHNNY
               Really? 
                                 BILLY
               Yes! 
                                           JOHNNY
               You? 
                                            MARK
               (MARK ARRIVES AT CLAUDETTE'S SIDE AND HOLDS HER SHOULDERS.) 
               It's okay. 
                               CLAUDETTE
               What's okay? He's involved with some sort of gang of hemale 
               trans­homo perverts!
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
40.               
               CONTINUED: (8) 
                                            MARK
               Come on, stop. It was a mistake. 
                               CLAUDETTE
               A mistake? That he leases his body to addicted drug homos? 
                                           JOHNNY
               (JOHNNY HOLDS BILLY'S HEAD IN HIS HAND.) 
               Let's go home. 
                                            MARK
               Come on, it's clear. 
                               CLAUDETTE
               What's clear? All you did was stand and watch. I'm going to 
               call the police. 
                                            LISA
               Mom stop! It was Billy's mistake, just stop! 
                                            MARK
               Let's go. 
               (MARK LEAVES WITH CLAUDETTE.) 
                                           JOHNNY
               Why did you this? You know better, right? Why!? 
                                 BILLY
               I'm sorry. 
                                           JOHNNY
               You know better Billy...you almost got killed! 
                                 BILLY
               I'm sorry, it won't happen again, I promise. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
41.               
               CONTINUED: (9) 
                                           JOHNNY
               Of course it won't. I made him....go away. 
                                            LISA
               I'm your older sister Billy, and you know that Johnny is like 
               your father. We are going to help you. I'm going home now. 
               (LISA EXITS THE ROOF LEAVING JOHNNY AND BILLY ALONE 
               TOGETHER.) 
                                 BILLY
               Are we still going to the movie tonight? 
                                           JOHNNY
               Oh, sure we are. 
                                 BILLY
               What kind of movie are we going to see, Vampires? 
                                           JOHNNY
               Well we'll see....Billy, don't plan too much, it may not come 
               out right. 
                                 BILLY
               Alright, let's toss the ball around. 
                                           JOHNNY
               Okay. 
               (JOHNNY AND BILLY BEGIN TO TOSS THE FOOTBALL FROM ONE END OF 
               THE ROOF TO THE OTHER.) 
                                 BILLY
               I got to tell you about something. 
                                           JOHNNY
               Shoot Billy. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
42.               
               CONTINUED: (10) 
                                 BILLY
               It's about me and you. 
                                           JOHNNY
               Go on. 
                                 BILLY
               You're just so cool and such a nice, caring guy. Everybody 
               likes you and only a fat, stupid, idiotic, selfish jerk with 
               a body odor problem would ever betray you. You help so many 
               people and you've been so good to me. 
                                           JOHNNY
               Go on. 
                                 BILLY
               I like you a lot, and I find myself sexually attracted to 
               you. I know you love Lisa and I shouldn't think of you in 
               that way, but I can't help it. I don't know, I'm just 
               confused. 
                                           JOHNNY
               Billy, don't worry about that. Lisa and I love you too, as a 
               person, as a human being, as a friend. You know people don't 
               have to say it, they can feel it. 
                                 BILLY
               What do you mean? 
               (JOHNNY AND BILLY SIT DOWN ON SOME SEATS AS THEY TALK.) 
                                           JOHNNY
               You can love someone deep inside your heart and there is 
               nothing wrong with it. If a lot of people love each other, 
               the world will be a better place to live. 
                                 BILLY
               But you're Lisa's future husband. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
43.               
               CONTINUED: (11) 
                                           JOHNNY
               Billy, don't worry about it. The important thing is that you 
               appreciate loyalty. You would never betray me and that's why 
               I do things like pay your rent for you. In fact, and this is 
               a secret, I have a small fortune built up that I'm waiting to 
               give away as a reward to all my friends who never betray me. 
                                 BILLY
               You mean you are not upset at me? 
                                           JOHNNY
               No, because I trust you and I trust Lisa, and Mark. You are 
               part of our family and we love you very much, as a friend. 
               But you are sort of like our son too, and we will help you 
               anytime. 
                                 BILLY
               Well, you're right. Thanks for paying my tuition. 
                                           JOHNNY
               You're very welcome Billy. Keep in mind that if you have any 
               problems, talk to me and I will help you. 
                                 BILLY
               Awesome. Thanks Johnny. 
                                           JOHNNY
               Let's go eat, huh. Come on, let's go. 
               (JOHNNY AND BILLY WALK TO EXIT THE ROOF.) 
                                           JOHNNY
               You must be starving. 
BILLY
               I am, Johnny. I am.
               (JOHNNY AND BILLY EXIT THE ROOF.) 
               END SCENE 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
44.               
               SCENE 11
               LISA ENTERS THE ROOM WITH DEPARTMENT STORE SHOPPING BAGS AND 
               HER FRIEND MICHELLE. THEY ARE TALKING AND LAUGHING. 
                                            LISA
               Would you like something to drink? 
               (SHE PUTS HER SHOPPING BAGS ON THE COUCH AND GOES TO THE 
               KITCHEN.) 
                                          MICHELLE
               (MICHELLE CALLS TO HER.) 
               What do you have? 
                                            LISA
               Vodka, brandy, rum, tequila, applejack, vermouth, cognac, 
               gin, and the whiskeys: bourbon, scotch, rye and Canadian. 
               I would go with the rum because it's 151 proof. 
                                          MICHELLE
               Hit me with a double! 
LISA/MICHELLE
               Let's get this party started! 
               (THEY LAUGH.) 
                                          MICHELLE
               How's Johnny? 
                                            LISA
               Not so good. He didn't get his promotion. 
                                          MICHELLE
               I'm sorry to hear that. Was he disappointed? 
                                            LISA
               Quite a bit. He got drunk last night and hit me. Now he's on 
               the roof trying to give advice to Billy. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
45.               
               CONTINUED:
                                          MICHELLE
               He hit you!?? How did that happen? 
                                            LISA
               He got drunk and didn't know what he was doing. 
               (THEY PREPARE DRINKS AND GO IN THE ROOM AND SIT DOWN.) 
                                          MICHELLE
               You poor thing. Are you okay? 
                                            LISA
               Well, I don't want to marry him anymore. 
                                          MICHELLE
               What??? I thought it was all planned. How is he in bed? 
                                            LISA
               He's okay, but I found somebody else. 
                                          MICHELLE
               What!?? And you're planning a birthday party for Johnny? 
                                            LISA
               Why not? He doesn't know anything about it. 
               (SHE GIGGLES.) 
               Pretty good, huh? 
                                          MICHELLE
               Look, this is not right. You are living with a one guy and 
               doing sex with another. 
                                            LISA
               I'm doing what I want to. 
                                          MICHELLE
               Does this new guy know Johnny? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
46.               
               CONTINUED: (2) 
                                            LISA
               (SHE IS SMILING.) 
               He's his best friend who lives in this building. 
                                          MICHELLE
               (MICHELLE TURNS AWAY AND THINKS FOR A MOMENT.) 
               I don't believe you're telling me this. 
               (SHE THINKS A LITTLE WHILE MORE.) 
               It's Mark, isn't it! You're not thinking about Johnny or 
               Mark. You're just thinking about yourself, Lisa. You can't go 
               on this way. Somebody's going to get hurt. You have to be 
               honest with Johnny. You can't go on like this. 
                                            LISA
               I can't do that. What will it do to Johnny? He would be 
               devastated and never recover. 
                                          MICHELLE
               Oh, so you're saying you are thinking about him and not 
               yourself? Well if you care so much for him, then why cheat on 
               him? 
                                            LISA
               Look I really don't know what to do. I love Mark. I really 
               don't have any more feelings for Johnny. 
                                          MICHELLE
               Johnny is so excited about this wedding. 
                                            LISA
               I know. 
                                          MICHELLE
               You've got to tell Johnny. 
                                            LISA
               No guilt trips. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
47.               
               CONTINUED: (3) 
                                          MICHELLE
               You don't feel guilty about this at all? 
                                            LISA
               No, I'm happy. 
                                          MICHELLE
               Something awful is going to happen. 
                                            LISA
               Please don't tell anybody. 
               (JOHNNY OPENS THE DOOR AND ENTERS THE FLAT. MICHELLE AND LISA 
               ARE STILL TALKING ON THE COUCH.) 
                                          MICHELLE
               Don't worry, you can trust me. You're secret is safe with me. 
                                           JOHNNY
               (JOHNNY ENTERS THE ROOM AND IS SURPRISED TO SEE MICHELLE.) 
               Hello Michelle, I heard you. What secret? 
               (JOHNNY SITS DOWN IN HIS CHAIR NEXT TO THE GIRLS.) 
                                            LISA
               It's between us women. 
                                          MICHELLE
               Hi Johnny. 
JOHNNY (TO LISA) 
               Did you get a new dress? 
                                          MICHELLE
               Well I guess I'd better be going. I'll just talk to you guys 
               later? Excuse me. 
               (MICHELLE WALKS TO THE DOOR AND OPENS IT.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
48.               
               CONTINUED: (4) 
MICHELLE (TO LISA) 
               Lisa, remember what I told you. 
               (MICHELLE WAVES AS SHE EXITS. LISA LOOKS UPSET.) 
                                           JOHNNY
               What's she talking about? 
                                            LISA
               It's women talk. Only women can talk about it! 
                                           JOHNNY
               (JOHNNY GETS UP AND PLACES HIS JACKET ON THE COUCH.) 
               I still don't believe I hit you. You shouldn't have any 
               secrets from me. I'm your future husband. 
                                            LISA
               Are you sure about that? Maybe I'll change my mind. 
                                           JOHNNY
               Don't talk like that. What do you mean? 
                                            LISA
               What do you think? Women change their minds all the time. 
                                           JOHNNY
               (JOHNNY LAUGHS AND PUTS HIS HANDS BEHIND HIS HEAD.) 
               Ha,ha! You must be kidding, aren't you? 
                                            LISA
               Look, I don't want to talk about it. I'm going to go 
               upstairs, wash up and go to bed. 
                                           JOHNNY
               (JOHNNY STANDS UP AND PUSHES LISA ONTO THE COUCH.) 
               How dare you talk to me like that! You should tell me 
               everything! What is it you don't want to talk about? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
49.               
               CONTINUED: (5) 
                                            LISA
               I can't talk right now. 
                                           JOHNNY
               (JOHNNY SITS DOWN NEXT TO LISA AND IS HYSTERICAL.) 
               Why Lisa! Why Lisa! Why don't you talk to me! Come on Lisa! 
               Lisa! Lisa! Lisa! Talk to me please! Without you I would be 
               nothing. You are my life, my everything, I could not go on 
               without you Lisa. 
                                            LISA
               You're scaring me. 
               (LISA STANDS UP AS IF TO HEAD UPSTAIRS. JOHNNY STANDS IN HER 
               FACE.) 
                                           JOHNNY
               You are lying! I never hit you. You are taking me apart, 
               Lisa!!!!! 
                                            LISA
               Why are you so hysterical!? 
                                           JOHNNY
               (HE TAKES HER BY THE SHOULDERS AND SHAKES HER.) 
               Do you understand life? Do you understand life? Do you? 
                                            LISA
               (LISA GETS UP AND WALKS UP THE STAIRS.) 
               Don't worry about it. Everything will be alright. 
               (SHE IS KISSING JOHNNY ON THE CHEEK AND GOES INTO THE 
               BATHROOM.) 
                                           JOHNNY
               You drive me crazy! 
               (HE IS SITTING ON A CHAIR AND THINKING. HIS FACE LOOKS VERY 
               WORRIED.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
50.               
               CONTINUED: (6) 
                                            LISA
               (SHE COMES OUT OF THE BATHROOM WITH A SEXY NIGHTGOWN ON AND 
               GOES TO BED.) 
               Goodnight, Johnny. 
                                           JOHNNY
               Don't worry about it, I still love you. Good night Lisa. 
               END SCENE 
               SCENE 12
               (LISA AND CLAUDETTE WALK INTO THE LIVING ROOM FROM THE 
               KITCHEN.) 
                                            LISA
               You look really tired today mom, are you feeling okay? 
                               CLAUDETTE
               I didn't get much sleep last night. 
                                            LISA
               Why not? What's wrong? 
               (LISA TOUCHES CLAUDETTE ON THE SHOULDER.) 
                               CLAUDETTE
               You remember my friend Shirley Hamilton? She wants to buy a 
               new house and I asked Johnny if he could help her with the 
               down payment. All he can tell me is that it's an awkward 
               situation. I expected your husband to be a little more 
               generous. 
                                            LISA
               He's not my husband. 
                               CLAUDETTE
               I know, but Johnny is part of our family. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
51.               
               CONTINUED: 
                                            LISA
               Mom, I don't love Johnny anymore. I don't even like him. I 
               had sex with someone else. 
                               CLAUDETTE
               (CLAUDETTE BREATHES DEEPLY.) 
               You can't be serious. 
               (JOHNNY IS HIDING BEHIND THE STAIRCASE AND LISTENING TO THE 
               CONVERSATION BETWEEN CLAUDETTE AND LISA.) 
                                            LISA
               You don't understand. 
                               CLAUDETTE
               Who, who is it? 
                                            LISA
               I don't want to talk about it. 
                               CLAUDETTE
               Oh no! It's that homework character with the underwear, isn't 
               it! I gave you strict orders not to sleep with that goofball. 
               Well, that's it. You leave me no other option than to disown 
               y... 
                                            LISA
               (LISA STARTS TALKING AND CUTS OFF CLAUDETTE BEFORE SHE CAN 
               FINISH.) 
               It's not Bran! Look, I just don't want to talk about it. 
                               CLAUDETTE
               You don't want to talk about it. Then why did you bring it up 
               in the first place? Have you lost your mind? Next thing 
               you'll be turning tricks like your brother. 
                                            LISA
               I don't know why I brought it up? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
52.               
               CONTINUED: (2) 
                               CLAUDETTE
               You don't know? You really are going crazy. 
               (CLAUDETTE POINTS THE FINGER AT LISA.) 
               I have to go pick up my breast cancer medicine. Can you 
               believe it's going to cost me $ 120.00? I think the whole 
               thing was made up just so they can make some easy money. 
               Imagine, taking advantage of an old defenseless lady who's 
               losing her life. 
                                            LISA
               Mom, just take the medicine and you'll be fine. Are you 
               coming to the party? 
                               CLAUDETTE
               Sure, I suppose so. 
               (CLAUDETTE WALKS TO THE DOOR. SHE OPENS THE DOOR AND LISA AND 
               CLAUDETTE EXIT. JOHNNY IS STILL BEHIND THE STAIRCASE. HE IS 
               IN SHOCK.) 
                                           JOHNNY
               How can they say this about me? I don't believe it. Lisa has 
               been unfaithful and that woman, her mother, cares more about 
               her "life threatening" cancer than she does about me. 
               (HE MAKES QUOTATION SIGNS WITH HIS FINGERS AS HE SAYS "LIFE 
               THREATENING".) 
               I'll show them, I'll record everything. 
               (JOHNNY WALKS DOWN THE STAIRCASE AND OVER TO THE TABLE WHERE 
               THE PHONE IS AND SITS DOWN. HE PULLS OUT A TAPE AND PLACES IT 
               INTO THE TAPE RECORDER, HE INSTALLS THE RECORDING DEVICE INTO 
               THE PHONE AND HIDES IT UNDER THE TABLE. JOHNNY THEN WALKS 
               AWAY AND GOES UPSTAIRS TO THE BEDROOM.) 
               END SCENE 
               SCENE 13
               (JOHNNY IS WALKING IN AN ALLEY AS BRAN STOPS HIM FROM BEHIND. 
               THEY SHAKE HANDS AND LAUGH.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
53.               
               CONTINUED: 
                                            BRAN
               Hey Johnny, what's going on? 
                                           JOHNNY
               Oh hi Bran, what's new? 
                                            BRAN
               Actually Johnny, I got a little bit of a tragedy on my hands. 
                                           JOHNNY
               Did Michelle betray you or something? 
                                            BRAN
               No, nothing horrible like that! I'd probably kill myself if 
               she ever did that. 
                                           JOHNNY
               Who wouldn't? So tell me what happened. 
                                            BRAN
               Me and Michelle were making out, at your place. 
                                           JOHNNY
               Uh huh. 
                                            BRAN
               And Lisa and Claudette sort of walked in on us in the middle 
               of it. That's not the end of the story. 
                                           JOHNNY
               Go on, I'm listening. 
                                            BRAN
               We're going at it and I get out of there as fast as possible. 
               I get my pants, I get my shirt, and I get out of there. And 
               then about half way down the stairs, I realize that I had 
               misplaced, I had forgotten something....my underwear. 
               (JOHNNY AND BRAN BEGIN TO LAUGH.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
54.               
               CONTINUED: (2) 
                                           JOHNNY
               Underwear? 
                                            BRAN
               So I come back to get it, you know, and I pretend that I need 
               a book, you know I'm looking for my book. I reach in and put 
               the underwear in my pocket and it sort of slides out, and 
               Claudette, she saw it sticking out of my pocket, and she 
               pulls it out and she's showing everybody me underwears. 
                                           JOHNNY
               You must be kidding. Underwear, I got the picture. 
                                            BRAN
               I don't know what to do? 
                                           JOHNNY
               Underwear, that's life. 
                                 BILLY
               (BILLY IS CARRYING A FOOTBALL AND WALKS INTO THE ALLEY.) 
               Hey Johnny. 
                                           JOHNNY
               Hey Billy. 
                                 BILLY
               Do you guys want to play some football? 
                                            BRAN
               I have to go see Michelle in a little bit, to make out with 
               her. So I'm sorry. 
                                           JOHNNY
               Oh come on! 
                                 BILLY
               What's the matter Bran, are you chicken? CHIP! CHIP!!! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
55.               
               CONTINUED: (3) 
                                           JOHNNY
               Ha Ha! CHIP!!! CHIP!!!! 
                                            MARK
               (MARK ARRIVES AND JOINS THE FUN MAKING. HE STARTS JUMPING UP 
               AND DOWN, FLAPPING HIS ARMS AND KICKING THE AIR.) 
               CHIP!!! CHIP!!! BBBBRRRRRRAAAAAAAAWWWWKK!!!! CAW!!! CAW!!!!! 
                                           JOHNNY
               Ha Ha! Oh hi Mark! 
                                            BRAN
               Okay guys, whatever. 
                                 BILLY
               Hey what's up Mark? 
                                            MARK
               Hey Billy, what's up? 
                                           JOHNNY
               Let's go for it. 
                                 BILLY
               I'm going out. 
               (BILLY GOES OUT AND CATCHES A PASS.) 
                                            BRAN
               Sorry you had to see that. 
                                 BILLY
               I'm not sorry. 
               (JOHNNY, BRAN, MARK, AND BILLY PLAY CATCH THE FOOTBALL AS 
               THEY LAUGH.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
56.               
               CONTINUED: (4) 
                                 BILLY
               Studying right? I don't study like that. 
                                            BRAN
               I bet you wish you did. 
               (BRAN NODS TOWARD JOHNNY. JOHNNY LAUGHS AT THE COMMENT.) 
                                 BILLY
               Catch it. 
                                            MARK
               What's going on you guys? 
                                 BILLY
               He's just telling us about an underwear issue. 
                                            MARK
               Underwear? What's that? 
                                            BRAN
               It's embarrassing man. I don't want to get into it. 
                                            MARK
               Underwear....It's the underpants man! 
               (MARK SUDDENLY JUMPS TO INTERCEPT A PASS. HE MISSES AND LANDS 
               WITH A HEAVY STOMP ON BRAN'S FOOT. MARK BENDS OVER TO CATCH 
               HIS BALANCE AND THE FOOTBALL BOUNCES OFF MARK'S BACK AND INTO 
               BRAN'S FACE. BRAN LOSES HIS BALANCE AND FALLS BACKWARD INTO 
               SOME TRASH CANS. THEY ALL RUSH TO HIS SIDE.) 
                                 BILLY
               Does anyone know CPR? 
                                           JOHNNY
               I do! Bran, are you okay? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
57.               
               CONTINUED: (5) 
                                 BILLY
               Are you okay? 
                                            BRAN
               I'm fine. 
                                            MARK
               Sure? 
                                            BRAN
               Uh huh. 
                                           JOHNNY
               Do you want to go see a doctor? 
                                            BRAN
               No, no, no. I'm good, I'm alright. I'm fine. 
                                           JOHNNY
               Yeah Mark, take him to a doctor, and Bran, listen if you need 
               anything call me anytime alright. We are very good friends 
               and I will do everything in my power to help you get better.  
               (MARK IS HELPING BRAN WALK AWAY.) 
                                 BILLY
               Take care of him Mark! 
               (BILLY PICKS UP THE FOOTBALL AND STARTS TO CRY.)
               Oh man....oh man, oh man. 
                                           JOHNNY
               (JOHNNY PUTS HIS ARM AROUND BILLY AND TOGETHER THEY START TO 
               SING AS THEY WATCH MARK AND BRAN HEAD OFF TO THE HOSPITAL.)
JOHNNY/BILLY
               Onward, Christian soldiers, marching as to war....
               END SCENE 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
58.               
               SCENE 14
               JOHNNY IS SITTING NEXT TO THE PHONE. HE LOOKS AROUND TO CHECK 
               THAT NO ONE IS AROUND THEN PULLS OUT THE TAPE RECORDER FROM 
               UNDER THE TABLE. HE PRESSES SOME BUTTONS ON THE ANSWERING 
               MACHINE AND MUFFLED VOICES ARE HEARD AS THE TAPE PLAYS. 
               JOHNNY IS SHAKING HIS HEAD AND LOOKING VERY DISTURBED. HE 
               SUDDENLY TAKES OUT THE TAPE AND HURLES IT ACROSS THE ROOM AS 
               HE SCREAMS. 
               THERE IS A RING OF THE DOORBELL AND JOHNNY WALKS OVER AND 
               OPENS THE DOOR. PETER, AN INTELLECTUAL AND A PSYCHOLOGIST WHO 
               WEARS GLASSES IS AT THE DOOR. JOHNNY INVITES HIM IN. 
                                           JOHNNY
               Oh hi Peter, I'm so glad you stopped by. Come in and have a 
               seat, I'll get some water for us to drink. 
               (PETER SITS DOWN ON THE COUCH AND JOHNNY GOES TO THE KITCHEN 
               AND COMES BACK WITH TWO GLASSES AND A PITCHER OF WATER WHICH 
               HE POURS FOR BOTH OF THEM. JOHNNY SITS DOWN.) 
               I don't understand women. Do you Peter? 
                                 PETER
               Of course I do. I'm a psychologist. What's the problem? 
                                           JOHNNY
               They never say what they mean, and they always play games. 
               (JOHNNY HANDS PETER A GLASS OF WATER.) 
                                 PETER
               Okay, what do you mean? 
                                           JOHNNY
               I have a serious problem with Lisa. I don't think she's being 
               faithful to me. In fact, I know she isn't. 
                                 PETER
               Lisa? Are you sure? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
59.               
               CONTINUED: 
                                           JOHNNY
               I'm sure. I overheard a conversation between Lisa and her 
               mother, and I recorded some phone conversations she had with 
               a guy who has a voice that coincidentally sounds very similar 
               to the voice of Mark, who is my best friend. What should I do 
               Peter? 
                                 PETER
               This is Lisa we are talking about? 
                                           JOHNNY
               Yeah. 
                                 PETER
               Are you sure? 
                                           JOHNNY
               Yes. 
                                 PETER
               What would you like me to say? 
                                           JOHNNY
               You are a psychologist, Peter. Don't you have some advice? 
                                 PETER
               (PETER IS STANDING AND DRINKING WATER.) 
               I am an expert, that's true, and it's not a very complicated 
               situation. But Johnny, you are my friend and I don't want to 
               get between you and Lisa. Look, I think you should confront 
               her and show her who's the man of the house. 
                                           JOHNNY
               I can't confront her, I have to give her a second chance. 
               After all she's my future wife. You know what they say, love 
               is blind. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
60.               
               CONTINUED: (2) 
                                 PETER
               It's not about love, Johnny. It's about control, and the best 
               way to control a female is to make them emotionally dependent 
               on you. You didn't do that, so Lisa found it somewhere else. 
               (THE DOORBELL RINGS.) 
               Did you hear the door? 
                                           JOHNNY
               Yeah. 
               (JOHNNY WALKS OVER AND OPENS THE DOOR.) 
               Oh hi Mark, come in. 
                                            MARK
               (MARK ENTERS WITH A BIG SMILE.) 
               Oh hey Johnny. Hey Peter. 
                                           JOHNNY
               We are just talking about women. 
                                            MARK
               (MARK CLOSES THE DOOR AND WALKS OVER TO THE CHAIR.) 
               Women, man, women just confuse me. Can't live with them, 
               can't live without them, but we need them for baby making. 
               (MARK SITS DOWN ON THE CHAIR.) 
               I have a girl, but she's married. She's very attractive. It's 
               driving me crazy. 
                                 PETER
               Why didn't you mention this before? I'm a psychologist. Is it 
               anyone I know? 
                                            MARK
               (HE IS DEFENSIVE.) 
               What do you mean, is it someone you know? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
61.               
               CONTINUED: (3) 
                                           JOHNNY
               Can I meet her? 
                                            MARK
               Why would you want to do that, Johnny? I mean, well, um, what 
               would Lisa think? It's an awkward situation. 
                                           JOHNNY
               Oh I see. You mean she's too old or you think I will take her 
               away from you? Huh? 
               (JOHNNY AND PETER LAUGH.) 
                                            MARK
               No! 
                                           JOHNNY
               I have my own problems. 
                                 PETER
               Tell me about your problems Johnny. 
                                           JOHNNY
               Peter, you always play psychologist with us. 
                                 PETER
               Look, I may be your friend, but by profession I am a 
               psychologist, and that makes me an expert on these issues. 
                                           JOHNNY
               Lisa is teasing me about whether we will get married or not, 
               and we haven't made love in awhile. I don't know what to do. 
                                 PETER
               What kind of man are you Johnny? People are people. Sometimes 
               they can't see their own faults, so they need someone to tell 
               them. You have to give it to her straight. It takes two to 
               tango Johnny, and if all she has are two left feet she'll 
               just end up stepping all over your toes. You're going to get 
               hurt. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
62.               
               CONTINUED: (4) 
                                            MARK
               Hey I'm thinking of moving to a better place man. I'm making 
               some good money. 
                                 PETER
               Look, you should tell her the truth. You are doing this for 
               your girl, right? 
                                           JOHNNY
               You are right Peter! Is she getting a divorce Mark? 
                                            MARK
               You guys are too much! Hey, are you running Bay to Breakers 
               this year? 
                                           JOHNNY
               I am, sure. 
                                 PETER
               No, I'm not going this year. 
                                           JOHNNY
               Ha, ha!! Chicken Peter, you are just a little chicken!!! 
               Chip!!! Chip!!! Chip!!!! Chip!!!!! Chip!!!! 
                                            MARK
               Ha Ha!! Squeak!!! Squeak!!!! Honk!!! Little Chicken!!!
                                 PETER
               Who are you guys calling a chicken? I just don't like all the 
               weirdos. There's too many weirdos. 
                                           JOHNNY
               I don't mind. Mark, do you remember the one with the big 
               tits, the blonde one? 
                                            MARK
               How about the one with the bridal gown and the sign? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
63.               
               CONTINUED: (5) 
                                           JOHNNY
               Oh yeah, "Please Marry Me". I almost took her up on it.
                                            MARK
               I never ate so much bread. 
                                           JOHNNY
               The barbecue chicken and rice was delicious. That was cool. 
                                 PETER
               You guys proved my point. You are both weird. You guys want 
               to play cards? 
                                           JOHNNY
               No, we can't. I expect Lisa any minute. 
                                            MARK
               Hey, who's king of the house? 
                                 PETER
               Yeah, you have to establish these guidelines before you get 
               married. How did you meet Lisa? you never told us. 
                                           JOHNNY
               It's a very interesting story. When I moved to San Francisco 
               I had two suitcases and I didn't know anyone. I hit the YMCA 
               with a two thousand dollar check that I couldn't cash. 
                                            MARK
               Why not? 
                                           JOHNNY
               Because it was an out of state bank. Anyway, I was working as 
               a bus boy in a hotel and Lisa was sitting, drinking her 
               coffee and she was so beautiful, and I say hi to her. That's 
               how we met. 
                                            MARK
               So, what's the interesting part? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
64.               
               CONTINUED: (6) 
                                 PETER
               Oh give us a break Mark! Isn't it obvious? A two thousand 
               dollar out of state bank issued check that he can't cash? Ha 
               Ha Ha! That's quite the conundrum. I'll bet it's never been 
               cashed, has it. 
                                           JOHNNY
               You're right Peter, on both counts. I had the uncashed check 
               laminated and placed in a photo album, which is indeed very 
               interesting. But, even more interesting is that Lisa was 
               living in San Francisco at the time. 
                                            MARK
               So? 
               (JOHNNY TAKES A DEEP BREATH AND PETER LOOKS AT THE FLOOR.) 
                                           JOHNNY
               Don't you see, Mark? Lisa had her own home in the city. She 
               did not need to stay in a hotel. She had some kind of 
               inexplicable urge to spend the night in that very hotel, 
               during my shift. It was meant to be! 
                                            MARK
               What, no tips from your job? 
               (JOHNNY AND PETER LOOK AT EACH OTHER WITH AWKWARD SILENCE.) 
                                           JOHNNY
               Whatever, do you guys want to eat something? 
               (JOHNNY WALKS OVER TO THE KITCHEN AS PETER AND MARK SHAKE 
               THEIR HEAD.) 
                                            LISA
               (LISA AND BILLY WALK IN. MARK TURNS AROUND AND LOOKS AT 
               LISA.) 
               Hey guys. What's going on? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
65.               
               CONTINUED: (7) 
                                 PETER
               Oh, hey Lisa. 
                                            MARK
               Hey Lisa. 
               (MARK GETS UP FROM THE CHAIR AND STANDS IN FRONT OF LISA AND 
               BILLY. BILLY IS LOOKING OUT THE WINDOW.) 
                                            LISA
               Where's Johnny? 
                                            MARK
               He's in the kitchen. I got to go. 
                                            LISA
               I didn't mean to chase you off. I wish you'd stick around for 
               awhile. 
                                            MARK
               Are you crazy? I have to be at work early. See ya. 
               (MARK LOOKS AT BILLY AND EXITS THE LIVING ROOM. PETER THEN 
               GETS UP AND LEAVES. BILLY SITS ON THE FLOOR.) 
                                            LISA
               Why are you sitting on the floor Billy? 
                                 BILLY
               It's hard to explain, you wouldn't understand. 
                                            LISA
               (SHE IS SCREAMING.) 
               You son of a bitch!!! What the hell is the matter with you!? 
               You're the reason I drink! If you don't get up this instant 
               I'm going to belt whip you so hard you'll wish you were going 
               to the moon! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
66.               
               CONTINUED: (8) 
                                 BILLY
               (BILLY STANDS UP FROM THE FLOOR.) 
               There, are you happy now? 
                                            LISA
               (STILL SCREAMING.) 
               I am happy!!! Look Billy! I have to talk to Johnny! I'll see 
               you later!!! 
                                 BILLY
               Will you tell him I said hello? 
                                            LISA
               Alright!!! 
                                 BILLY
               Yes! 
               (WITH AN OBNOXIOUS GRIN, BILLY SARCASTICALLY SKIPS TO THE 
               FRONT DOOR AND EXITS, THEN LISA STOMPS INTO THE KITCHEN.) 
               END SCENE 
               ACT III
               SCENE 15
               PETER COMES OUT OF THE DOOR TO THE ROOF AND FINDS MARK 
               SITTING ON THE BENCH LOOKING DEPRESSED. 
                                 PETER
               Oh, hi Mark. What's happening? 
                                            MARK
               Hi Peter. 
                                 PETER
               (PAUSE.) 
               This is a good place to think, huh? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
67.               
               CONTINUED: 
                                            MARK
               (MARK PULLS A JOINT OUT OF HIS POCKET AND LIGHTS IT.) 
               You wanna put me on the clock? 
                                 PETER
               What's that? 
               (HE POINTS AT THE JOINT.) 
                                            MARK
               (HE OFFERS THE JOINT TO PETER.) 
               You want some? 
                                 PETER
               No man. You know I don't smoke that stuff. You look 
               depressed. 
                                            MARK
               I got this sick feeling in my stomach. I did something awful. 
               I just can't forgive myself. 
                                 PETER
               Why don't you tell me about it? 
                                            MARK
               Well, I feel like running, or killing myself. Something crazy 
               like that. 
                                 PETER
               Why are you smoking that crap? No wonder you can't think 
               straight. That stuff will mess up your brain. 
                                            MARK
               Anyway, it's none of your business. Why are you so nosy? You 
               think you know everything. You don't know shit. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
68.               
               CONTINUED: (2) 
                                 PETER
               Just a minute. Who do you think you are? You're acting like a 
               kid. Grow up. 
                                            MARK
               (MARK THROWS THE JOINT TO THE FLOOR AND SMASHES IT OUT WITH 
               HIS SHOE, AND HE IS YELLING.) 
               Who are you calling a kid? Fuck you! 
                                 PETER
               (PETER GRABS HIM BY THE ARM AND THEY STAND UP TOGETHER.) 
               Cool it Mark. I'm just trying to help you. I know you're 
               having an affair with Lisa. Am I wrong? 
                                            MARK
               (HE JERKS HIS ARM AWAY FROM PETER'S GRIP AND HITS HIM IN THE 
               FACE WITH HIS FIST. HE KNOCKS HIM DOWN. PETER IS UNCONSCIOUS. 
               MARK STARES AT HIM.) 
               Wake up man. Wake up 
               (HE LOOKS AROUND AND SEES A BUCKET OF WATER, GRABS IT AND 
               POURS IT ON PETER'S FACE.) 
                                 PETER
               (PETER SHAKES HIS HEAD AND SLOWLY WAKES UP. THEN HE SITS UP.) 
               What are you doing? Are you crazy? 
                                            MARK
               I'm sorry, I didn't mean it. You're my best friend. Are you 
               okay? 
                                 PETER
               Don't worry about it. Let's just talk about your problem. 
               (PETER TAKES HIS SHIRT OFF AND WIPES HIS FACE WITH IT.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
69.               
               CONTINUED: (3) 
                                            MARK
               (MARK SITS NEXT TO PETER.) 
               Are you sure you're okay? 
               (PAUSE.) 
               Why do you want to know my secret? Well, you're right, it's 
               Lisa. I don't know what to do. I'm so depressed. I think I'll 
               kill myself. Johnny is my best friend. She's so manipulative. 
                                 PETER
               How did this happen? If Johnny finds out that will be the end 
               of your friendship. What were you thinking? Look, life is 
               very complex, but you have to face it. You should have to be 
               responsible. My advice to you is that you should stop 
               thinking about her, and never do sex with her. Find another 
               girl. That's my advice. Lisa's a sociopath. She only cares 
               about herself, and she's incapable of loving anyone. 
                                            MARK
               Whatever Peter. Let's go. 
               (THEY GO OUT THE DOOR.) 
               END SCENE 
               SCENE 16
               JOHNNY IS ON THE PHONE DRESSED IN A TUXEDO. 
                                           JOHNNY
               Oh thank you. Thanks a lot. 
               (JOHNNY HANGS UP THE PHONE. BILLY ENTERS, ALSO DRESSED IN A 
               TUXEDO AND HOLDING A FOOTBALL.) 
                                           JOHNNY
               Oh hi Billy. That was some funeral wasn't it. 
                                 BILLY
               Yeah, I'm just glad it's over. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
70.               
               CONTINUED: 
                                           JOHNNY
               Billy, we had to make sure Jimmy was really dead. Now that we 
               all saw him lain down in that funeral casket we can be sure 
               he'll never trouble you ever again for his money. 
                                 BILLY
               There's just some things I don't understand Johnny. 
                                           JOHNNY
               Like what? Death? The meaning of life? Love? 
                                 BILLY
               No, I mean what happened at the police station. Didn't you 
               take Jimmy straight there? It's all very strange. 
                                           JOHNNY
               Well you know, the police have to deal with all sorts of 
               crazy people. So, sometimes at the station the police have to 
               do what may seem to us like some strange things. 
                                 BILLY
               But they said all his blood was sucked out of his body. 
                                           JOHNNY
               Some very....strange things. 
                                 BILLY
               (THE DOORBELL RINGS. BILLY OPENS THE DOOR AND PETER WALKS IN 
               WEARING A TUXEDO.) 
               Hey Peter, come in. 
                                 PETER
               It's too bad about Jimmy. I know he was a bad guy, but that 
               was just crazy. Besides, funerals are so depressing.
                                           JOHNNY
               Hey that's life. Have a seat Peter. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
71.               
               CONTINUED: (2) 
               (PETER SITS DOWN ON A CHAIR. THE DOORBELL RINGS AGAIN AND 
               BILLY OPENS THE DOOR. MARK ENTERS CLEAN SHAVEN AND HAS A BIG 
               SMILE. HE IS WEARING A TUXEDO.) 
                                 BILLY
               Wow! 
                                           JOHNNY
               Wow! 
                                            MARK
               Hey guys. You like it? 
PETER/JOHNNY/BILLY
               YEAH! 
                                           JOHNNY
               You look great. You look like babyface. 
                                 PETER
               What's the occasion Mark? 
                                            MARK
               I started a new job and they told me I can't show up there 
               looking like a caveman. So there you have it. 
                                 BILLY
               What did you think of the funeral Mark? We were looking for 
               you.
                                            MARK
               What funeral? 
                                 BILLY
               Okay..... Hey, you guys want to play some catch the football? 
                                 PETER
               In tuxes, you gotta be kidding? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
72.               
               CONTINUED: (3) 
                                 BILLY
               Come on Mark, let's do it. 
                                            MARK
               I'm up for it. 
                                 BILLY
               Johnny? 
                                           JOHNNY
               Ask Mr. Glasses­Head over there. 
                                 BILLY
               Come on Peter. 
                                 PETER
               No, I don't think so. 
                                 BILLY
               Please?? Come on. CHIP!!!!! 
BILLY/JOHNNY
               CHIP!!!! CHIP!!! 
               (BILLY AND JOHNNY MAKE CHICKEN NOISES AS THEY FLAP THEIR 
               ARMS.) 
                                            MARK
               (MARK STARTS PRANCING AROUND THE ROOM, CLAPPING HIS HANDS.) 
               HEE­HAW!! MOOOO!!!! RIBBIT!!! RIBBIT!!!!! PRA­SKWWWAAAWWW!!!! 
               END SCENE 
               SCENE 17
               JOHNNY, MARK, BILLY, AND PETER ALL RUN OUT TOGETHER, YELLING, 
               AND BEGIN TO PLAY CATCH THE FOOTBALL. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
73.               
               CONTINUED: 
                                 BILLY
               Catch Johnny! Nice snag! All right Peter! Here we go Mark! 
               Come on! 
               (BILLY MAKES A GREAT CATCH FROM MARK.) 
               Catch Mark. 
                                            MARK
               (MARK WINDS UP AND MOTIONS TO PETER THAT HE'S GOING TO THROW 
               A LONG BOMB.) 
               Go, go... 
               (PETER RUNS DEEP AND FALLS FLAT ON HIS FACE. HIS LEG IS HURT. 
               MARK, BILLY, AND JOHNNY RUSH OVER TO SEE IF HE'S OKAY.) 
                                 BILLY
               Gee Mark, why don't you try NOT hurting someone for a change. 
                                 PETER
               It's not his fault. It's those damn drugs!
                                           JOHNNY
               Come on, let's go see a doctor. 
               (MARK, JOHNNY, AND BILLY HELP PETER GET UP AND THEY ALL WALK 
               OFF TOGETHER.) 
               END SCENE 
               SCENE 18
               JOHNNY IS IN THE KITCHEN GETTING READY FOR WORK, AND LISA IS 
               STILL ASLEEP. HE FINISHES HIS BREAKFAST, THEN HE GOES OVER TO 
               THE ANSWERING MACHINE AND PRESSES A FEW BUTTONS. THE TAPE 
               RECORDER STARTS PLAYING AND MUFFLED VOICES ARE HEARD. JOHNNY 
               LOOKS VERY ANGRY. HE PRESSES SOME MORE BUTTONS THEN REGAINS 
               HIS COMPOSURE. 
                                           JOHNNY
               (JOHNNY GOES OVER TO LISA AND KISSES HER ON THE CHEEK.) 
               Bye Lisa. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
74.               
               CONTINUED: 
               (JOHNNY GOES OUT THE DOOR.) 
                                            LISA
               (LISA WAKES UP AND GOES TO THE KITCHEN AND FIXES HERSELF A 
               CUP OF COFFEE. SHE GOES TO THE PHONE AND DIALS A NUMBER.) 
               Hello mom. How are you? 
                               CLAUDETTE
               I'm okay. How are you? 
                                            LISA
               There it us again. 
                               CLAUDETTE
               What are you talking about? 
                                            LISA
               That clicking noise. The phone's been making a strange sound 
               lately. 
                               CLAUDETTE
               You should report it to the phone company. Utilities are very 
               expensive these days. Did you call a repair technician? 
                                            LISA
               No, I think I'll just by a new phone. There's a Radio­Shack 
               nearby. 
                               CLAUDETTE
               Well, as long as Johnny's paying for it. So, how are you? 
                                            LISA
               I'm fixing the apartment for Johnny's birthday, but I'm 
               really not into it. 
                               CLAUDETTE
               Why not? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
75.               
               CONTINUED: (2) 
                                            LISA
               Oh, I don't want to get married. I love Mark. Don't you 
               understand that? 
                               CLAUDETTE
               It's not right Lisa. You should still keep Johnny because 
               he's very independent, and you ain't. Think about the money. 
                                            LISA
               Yeah, but I'm not happy anymore. Before I met Mark I didn't 
               think he would blow my mind. 
                               CLAUDETTE
               What are you talking about? You weren't meant to be happy. I 
               haven't been happy since I got married for the first time. I 
               didn't want to marry your dad either. I've been miserable 
               since then. It's true, men are all assholes. You have to use 
               them and abuse them. There's nothing wrong with that. 
                                            LISA
               I know. Johnny's okay, and I have him wrapped around my 
               little finger. 
                               CLAUDETTE
               Well, then you should be happy. 
                                            LISA
               But, I don't love him. 
                               CLAUDETTE
               Don't throw your life away just because you don't love him. 
               That's ridiculous. You've got to grow up and listen to me. 
                                            LISA
               Okay, I'll see you at the party then. 
                               CLAUDETTE
               Bye. 
               END SCENE 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
76.               
               SCENE 19
               JOHNNY AND MARK ENTER A COFFEE SHOP AND APPROACH THE COUNTER. 
               WE SEE STEAMED MILK BEING PREPARED BY SUSAN, THE BARISTA. 
               JOHNNY IS READING SOME FINE PRINT ON A FOLDER AND HOLDING THE 
               FOLDER DIRECTLY IN FRONT OF HIS FACE, COVERING IT FROM VIEW. 
                                           JOHNNY
               Hi, can I have a hot chocolate please? 
               (JOHNNY THEN PUTS DOWN THE FOLDER, REVEALING HIS FACE.) 
SUSAN
               Oh hi Johnny! I didn’t know it was you. What size would you 
               like? 
                                           JOHNNY
               Medium. 
SUSAN
               Sure. 
               (SHE LOOKS AT MARK.) 
               How about you? 
                                            MARK
               I'll have a mint tea. 
SUSAN
               Medium also? 
                                            MARK
               Whatever floats your boat. 
SUSAN
               Go sit down. We'll be right there. 
               (MARK AND JOHNNY GO SIT DOWN AT A TABLE.) 
                                            MARK
               Man, I'm so tired of girl's games. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
77.               
               CONTINUED: 
                                           JOHNNY
               What happened now Mark? 
                                            MARK
               Relationships never work man, I don't know why I waste my 
               time. 
                                           JOHNNY
               What makes you say that? 
                                            MARK
               It's not that easy Johnny. 
                                           JOHNNY
               Well, you should be happy Mark. 
                                            MARK
               Yeah I know. Life is too short. 
                                           JOHNNY
               Maybe for you it is. 
               (SUSAN BRINGS BY THEIR BEVERAGES TO JOHNNY AND MARK.) 
                                           JOHNNY
               Oh thank you Susan. 
SUSAN
               You're welcome. Now how about something you can really get 
               into with a fork, like cheesecake? 
                                            MARK
               No! 
                                           JOHNNY
               No, not today, maybe some other day. But thanks for thinking 
               about it. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
78.               
               CONTINUED: (2) 
SUSAN
               Real good. Okay then. Fine, alright. 
               (JOHNNY AND MARK ARE DRINKING THEIR DRINKS.) 
                                            MARK
               How was work today? 
                                           JOHNNY
               Pretty good. We got a new client and the bank will make a lot 
               of money. 
                                            MARK
               What client? Do I know him? What's his name?
                                           JOHNNY
               I can't tell you, it's confidential. 
                                            MARK
               Oh come on man, why not? I thought we were best friends. 
                                           JOHNNY
               No, I cannot. Anyway, how's your sex life? 
                                            MARK
               I can't talk about it. 
                                           JOHNNY
               Why not, are you hiding something? 
               (MARK GETS NERVOUS.) 
SUSAN
               (AT THAT VERY MOMENT SUSAN COMES OVER AND PUTS THE BILL DOWN 
               ON THE TABLE.) 
               Take your time. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
79.               
               CONTINUED: (3) 
                                            MARK
               (MARK PICKS UP THE BILL AND SEES AN OPPORTUNITY TO DRAW 
               JOHNNY'S ATTENTION AWAY FROM THEIR DISCUSSION. HE YELLS AT 
               SUSAN.) 
               You son of a bitch!!! I didn't order this! 
SUSAN
               (SUSAN RUSHES OVER.) 
               What's wrong!? 
                                            MARK
               Oh, whoops. I made a mistake, you were right. 
                                           JOHNNY
               (JOHNNY LOOKS DOWN AT HIS WATCH.) 
               Oh god I have to run. 
                                            MARK
               Already? 
                                           JOHNNY
               Yeah, I'm sorry. 
                                            MARK
               Alright, it's on me. 
                                           JOHNNY
               Wow! You really are the best friend a guy could ever have. 
               See you Mark.
                                            MARK
               By the way, do you want to go jogging in Golden Gate Park? 
                                           JOHNNY
               Yeah sure, what time? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
80.               
               CONTINUED: (4) 
                                            MARK
               Golden Gate Park....about six thirty? 
                                           JOHNNY
               Yeah, right on. Cool! 
               (JOHNNY GETS UP, SHAKES MARK'S HAND AND GRABS HIS DRINK.) 
               Okey, Dokey 
               (JOHNNY RUSHES OUT. MARK SIPS HIS TEA AND SMIRKS COYLY.) 
               END SCENE 
               SCENE 20
               (MARK AND LISA ENTER THE BEDROOM THROUGH THE STAIRCASE. LISA 
               GRABS MARK AGGRESSIVELY.) 
                                            MARK
               What's going on here? 
                                            LISA
               I like you very much, Sparky Marky. 
                                            MARK
               Look come on, Johnny's my best friend. 
               (LISA GIGGLES.) 
                                            LISA
               Just one more time. 
               (LISA GRABS MARK, REMOVES HIS SWEATER AND TOSSES HIM ONTO THE 
               BED. LISA AND MARK BEGIN TO KISS INTENSELY.) 
                                            MARK
               Oh yeah. 
               (MARK AND LISA CONTINUE TO GET MORE INTENSE AS THE LIGHTING 
               FADES TO BLACK.) 
               END SCENE 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
81.               
               SCENE 20
               MARK IS SITTING UNDER A TREE AS JOHNNY ARRIVES IN HIS CAR, 
               BLASTING RAP MUSIC. THEY SHAKE HANDS AND START JOGGING. 
                                            MARK
               Live fast, die young. 
                                           JOHNNY
               Yeah that's the idea. You're right! 
                                            MARK
               It's better to burn out than fade away. 
                                           JOHNNY
               Yeah, that's it bro!! 
                                            MARK
               In the warrior's code there's no surrender. 
                                           JOHNNY
               You got it Mark, that's the one!!! 
                                            MARK
               When there's thunder in your heart, every move is like a 
               lightning. 
                                           JOHNNY
               Yes!!! Right on! Ha Ha! 
               (JOHNNY AND MARK JOG TO THE FINISH.) 
               END SCENE 
               SCENE 21
               LISA IS SWEEPING THE FLOOR AS THE DOORBELL RINGS. 
                                            LISA
               Who is it? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
82.               
               CONTINUED: 
                                            MARK
               Delivery man....it's me Mark. Come on open up. 
                                            LISA
               Mark's not here man. 
               (THEY ARE LAUGHING.) 
               Okay, come on in. 
               (MARK ENTERS THE ROOM CARRYING BAGS OF GROCERIES.) 
                                            LISA
               Hey Mark. 
                                            MARK
               Wow, so are you going to be ready? 
                                            LISA
               How do you mean that? I'm always ready for you. 
                                            MARK
               I mean for the party. 
                                            LISA
               We have plenty of time. All I have to is put on my party 
               dress. Come on. 
               (LISA THROWS THE BROOM ASIDE AND TAKES OFF HER TOP. MARK 
               STARES AT HER IN DISMAY.) 
                                            MARK
               Wait, what are you doing? 
                                            LISA
               Nothing. 
               (LISA REMOVES MARKS SWEATER AND THEY FALL ONTO THE COUCH 
               TOGETHER AND BEGIN TO KISS. MARKS ZIPPER IS UNDONE.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
83.               
               CONTINUED: (2) 
                                            MARK
               Hold on, what about Johnny? 
                                            LISA
               I sent him out to buy groceries. 
                                            MARK
               Clever girl. You are so beautiful. 
               (THEY CONTINUE TO MAKE OUT AND KISS INTIMATELY. THERE'S A 
               SUDDEN KNOCK AT THE DOOR WHICH PROPELS MARK AND LISA TO JUMP 
               UP AND GET DRESSED IN A HURRY.) 
                                            LISA
               Hurry up, I have to answer the door. 
                                            MARK
               Wait! hang on, hang on, hang on. 
               (MARK IS STRUGGLING TO GET HIS SWEATER ON.) 
                                            LISA
               Who is it? 
                                          MICHELLE
               It's me, Michelle. I brought the stuff. 
                                            LISA
               Michelle's not here man. 
               (MARK AND LISA EXPLODE WITH LAUGHTER. AFTER A MINUTE THEY 
               CALM DOWN.) 
               Okay Michelle. It's open, come on in. 
               (MICHELLE COMES IN CARRYING A GROCERY BAG AND IS SHOCKED TO 
               SEE MARK ADJUSTING HIS CLOTHES.) 
                                            LISA
               How are you doing? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
84.               
               CONTINUED: (3) 
                                          MICHELLE
               Hi, I'm fine. I brought the stuff. 
                                            LISA
               I knew I could count on you. 
                                          MICHELLE
               Hi Mark, XYZ. 
                                            MARK
               What are you talking about? Are you crazy or something? 
                                          MICHELLE
               Examine your zipper. 
                                            MARK
               (MARK LOWERS HIS HEAD AND CAREFULLY EXAMINES HIS ZIPPER, 
               LOOKING AT IT CLOSELY AND REPEATEDLY TESTING THAT IT CLOSES 
               AND OPENS CORRECTLY.) 
               It seems okay to me. 
                                            LISA
               Come on you guys, I'm trying to prepare for the party. 
                                          MICHELLE
               So what can i do to help? 
                                            MARK
               (MARK IS STILL CHECKING HIS ZIPPER.) 
               You can help by telling me what's wrong with my zipper. 
               (MICHELLE AND LISA LAUGH AND THEY SIT DOWN ON THE COUCH 
               TOGETHER. MARK EXITS THROUGH THE FRONT DOOR WHILE STILL 
               LOOKING AT HIS ZIPPER, REPEATEDLY ZIPPING IT UP AND DOWN.) 
                                          MICHELLE
               What was he doing here? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
85.               
               CONTINUED: (4) 
                                            LISA
               Oh, he brought some take­out. 
                                          MICHELLE
               What about his zipper!!!! 
               (MICHELE AND LISA LAUGH HYSTERICALLY.) 
                                            LISA
               Leave him alone. He's a nice guy. 
                                          MICHELLE
               No, I mean­did something happen? 
                                            LISA
               He tried to rape me, but I didn't let him. 
                                          MICHELLE
               Did you tell Johnny yet? 
                                            LISA
               No, they are good friends. 
                                          MICHELLE
               I know. Tricky! Tricky! 
                                            LISA
               You know, I really loved Johnny at first. 
                                          MICHELLE
               Really? I thought you loved him now. 
                                            LISA
               Until now I did. I think I still love him. Everything's 
               changed. I need more from life than what Johnny can give me. 
               Suddenly my eyes are wide open and I see the light. I want it 
               all. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
86.               
               CONTINUED: (5) 
                                          MICHELLE
               Do you think you can get it all from Mark? 
                                            LISA
               I want to play the field. If he doesn't give me what I want 
               then somebody else will. 
                                          MICHELLE
               I think I don't know you anymore. 
               (MICHELLE IS LAUGHING.) 
               (PAUSE.) 
               You are being so manipulative Lisa. 
                                            LISA
               So what, you can learn from me. 
               (LISA LAUGHS.) 
               (PAUSE.) 
               You have to take as much as you can. You have to live, live, 
               live my friend. Don't worry, I have everything covered. 
                                          MICHELLE
               Tell me more. Maybe I can understand your point of view. 
                                            LISA
               Look, I don't want to talk about it. Let's put this stuff in 
               bowls. We only have an hour before people start coming. 
               (LISA AND MICHELLE CARRY ON PARTY PREPARATIONS WHILE THEY ARE 
               TALKING.) 
                                          MICHELLE
               I want to know, it's important to me. You're my best friend. 
               This really upsets me. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
87.               
               CONTINUED: (6) 
                                            LISA
               I don't know what the big mystery is. Doesn't everybody look 
               out for number one? Aren't I worth it? Don't I deserve the 
               best? 
                                          MICHELLE
               I can't do that. You are too much for me Lisa. 
                                            LISA
               You're not such an angel yourself. 
                                          MICHELLE
               We're not talking about me. 
               (MICHELLE THROWS A CHERRY TOMATO AT LISA. LISA THROWS A PRAWN 
               IN MICHELLE'S FACE. THEY BOTH PLAYFULLY LAUGH.) 
                                            LISA
               Stop it, they'll be here any minute. Are you trying to ruin 
               my party? 
                                          MICHELLE
               I'm with you, let's talk later. It looks to me like we're 
               ready. 
               END SCENE 
               ACT IV
               SCENE 22
               JOHNNY IS SITTING INSIDE HIS CAR WHICH IS PARKED OUTSIDE THE 
               APARTMENT. HE PUTS A TAPE IN THE CAR TAPE PLAYER AND PRESSES 
               PLAY. WE HEAR THE VOICES OF MARK AND LISA. 
VOICE OF MARK
               We sure fooled Johnny, didn't we. He doesn't suspect a thing! 
               We could carry on right under his nose and he wouldn't be the 
               wiser. He still thinks I'm his best friend! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
88.               
               CONTINUED: 
VOICE OF LISA
               Johnny does whatever I tell him. I have him totally whipped. 
               The best part is he totally trusts me and thinks I will never 
               betray him. 
VOICE OF MARK
               I know. What a dope! Har har har!!! 
VOICE OF LISA
               He's as good in bed as he is at getting promotions.... Awful! 
               (JOHNNY STOPS THE TAPE, THEN POUNDS HIS CHEST WITH HIS FISTS 
               AND SCREAMS.) 
               END SCENE 
               SCENE 23
               LISA IS WEARING A LITTLE BLACK DRESS AND IS SITTING ON THE 
               COUCH. SHE EAGERLY LOOKS AT THE CLOCK AND WAITS A FEW 
               MOMENTS. SUDDENLY THERE IS THE SOUND OF A KEY OPENING THE 
               DOOR. THE DOOR OPENS AND JOHNNY ENTERS. HE IS VERY ANGRY. 
                                            LISA
               Hi honey. happy birthday! 
                                           JOHNNY
               (THE ANGRY LOOK ON JOHNNY'S FACE FADES.) 
               Thank you. 
CROWD
               (JUST THEN A DOOR OPENS AND A CROWD OF PEOPLE COMES OUT.) 
               Surprise!!! 
               (THE CROWD BEGINS TO SING HAPPY BIRTHDAY TO JOHNNY.) 
               Happy Birthday to you, happy birthday to you... 
                                           JOHNNY
               Oh wow! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
89.               
               CONTINUED: 
CROWD
               Happy Birthday dear Johnny... 
                                           JOHNNY
               Wow, alright, thank you.. 
CROWD
               Happy Birthday to you.. 
                                           JOHNNY
               Thank you, thank you. 
BILLY
               (IN A SINGING VOICE.) 
               And many more....! 
               (EVERYONE IS LAUGHING AND CHEERING.) 
                                           JOHNNY
               (JOHNNY TURNS TO LISA.) 
               I'll talk to you later. 
               (SEVERAL GUYS SHAKE JOHNNY'S HAND. THE GUYS SLAP HIM ON HIS 
               BACK, AND THE GIRLS SLAP HIS BEHIND AND KISS HIM ON THE 
               CHEEK, AND SOME OF THEM GIVE HIM PRESENTS. HE PUTS THEM ON 
               THE COFFEE TABLE. JOHNNY PRETENDS TO BE HAPPY, BUT HE IS 
               GLANCING AT LISA. FOR A WHILE THERE IS GENERAL CONVERSATION 
               AND LAUGHING.) 
               END SCENE 
               SCENE 24
               THE PARTY CONTINUES TO GROW AS EVERYONE IS HAVING A GREAT 
               TIME. PEOPLE ARE MINGLING, DANCING, DRINKING, AND LAUGHING. 
               MARK AND LISA CATCH EYES AND FLIRT AS JOHNNY TAKES NOTICE. 
               BRAN AND MICHELLE FLIRT AS MICHELLE FEEDS HIM A PIECE OF 
               CHOCOLATE CAKE AND BRAN FEEDS HIMSELF IN A JOKING MANNER. 
               LISA WALKS OVER TO THEM AND LAUGHS. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
90.               
               CONTINUED: 
                                            LISA
               Hey everybody, let's go outside for some fresh air! 
               (EVERYBODY CHEERS AND BEGINS TO LEAVE THE ROOM. LISA STOPS 
               MARK AT THE DOOR. SHE CLOSES IT AND GRABS HIM.) 
               Wait, I have something i want to show you. 
                                            MARK
               What is it? 
               (MARK AND LISA WALK OVER AND SIT DOWN ON THE COUCH. SHE 
               PLACES HER LEGS ON MARK'S LAP.) 
                                            MARK
               So, what do you want to show me? 
                                            LISA
               It's a surprise. 
               (MARK AND LISA BEGIN TO KISS.) 
                                            MARK
               Oh, I love surprises! But what are you doing? Are you crazy? 
               Everybody's here. 
                                            LISA
               No they're not. They're all outside. 
               (MARK AND LISA ARE GIGGLING.) 
                                            MARK
               Lisa, you diabolical....you planned this all along! Now
               where's the surprise? 
               (LISA LAUGHS AND THEY KISS. SUDDENLY THE DOOR OPENS AND PETER 
               COMES IN WHILE MARK AND LISA ARE KISSING.) 
                                 PETER
               What's going on here!? 
               (LISA AND MARK STAND UP IN SHOCK.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
91.               
               CONTINUED: (2) 
                                 PETER
               Why are you doing this!? 
                                            MARK
               It's a surprise! 
                                            LISA
               Mark and I are two consenting adults. We have the right. 
                                 PETER
               Well I don't approve. Now I want to know why you are doing 
               this. Why!? 
                                            LISA
               I love him. 
                                 PETER
               I don't believe it. 
                                            MARK
               You don't understand anything. Leave your stupid comments in 
               your pocket. 
                                 PETER
               Excuse me? 'MY' stupid comments!? Here's some words of wisdom 
               for YOU, you comment making idiot. You think your opinions 
               are so important and that you possess some natural­born 
               expertise. But take it from ME, a REAL expert, when I say 
               that your comments are even more stupider than you, the very 
               person making them. Now, I have a lot of experience, so when 
               I say something, it counts. That's because I'm very important 
               and I know what I'm talking about, unlike feeble­minded you. 
               I see you want to make a retort with a comment, do you? 
               PSHAW!!! You can't make a comment because you're speechless, 
               and you're too AFRAID. Besides, No one wants to hear your 
               stupidness anyway. 
               (MARK STORMS OUT THE DOOR, SPEECHLESS, FURIOUS, AND AFRAID.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
92.               
               CONTINUED: (3) 
PETER (TO LISA)
               Do you understand what you are doing? You are going to 
               destroy Johnny. He is very sensitive. 
                                            LISA
               I don't care. I'm in love with Mark. 
                                 PETER
               How can you do this? You make me sick! 
                                           JOHNNY
               (THE DOOR OPENS AND JOHNNY COMES IN WITH MICHELLE.) 
               Thank you honey, this is a beautiful party. You invited all 
               my friends. Good thinking. 
                                            LISA
               You're welcome darling. You know how much I love you. 
                                           JOHNNY
               I do, Ha Ha Ha. 
                                            LISA
               You know, it's getting really hot in here. Why don't we go 
               back outside. 
                                           JOHNNY
               Uh huh. 
               (LISA AND PETER MAKE THEIR WAY TO THE DOOR, AND EVERYBODY 
               EXITS AS JOHNNY CLOSES THE DOOR.) 
               END SCENE 
               SCENE 25
               THE PARTY IS NOW TAKING PLACE ON THE ROOF AS PEOPLE ARE 
               DRINKING, LAUGHING, AND MINGLING. JOHNNY IS STANDING IN THE 
               MIDDLE OF THE CROWD. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
93.               
               CONTINUED: 
                                           JOHNNY
               Hey everybody, I have an announcement to make. We are 
               expecting! 
               (EVERYBODY CONGRATULATES JOHNNY BY SHAKING HIS HAND AND 
               PATTING HIM ON THE BACK AND BEHIND. IT'S ALL SMILES AND 
               LAUGHTER. HOWEVER, PETER AND MICHELLE STAND TOGETHER, LOOKING 
               VERY WORRIED. MICHELLE TAKES LISA BY THE HAND AND LEADS HER 
               TO AN UNOCCUPIED CORNER, AND PETER JOINS THEM.) 
                                          MICHELLE
               Lisa, you have to be honest with Johnny. 
                                 PETER
               I agree with that. 
                                          MICHELLE
               (MICHELLE LOOKS AROUND.) 
               You know what's going on? 
                                 PETER
               (PETER NODS HIS HEAD.) 
               Um hmmm. 
                                            LISA
               Look, I'm going to tell him. I just don't want to spoil his 
               birthday. 
                                 PETER
               When is the baby due? 
                                            LISA
               There is no baby. 
MICHELLE/PETER
               What!? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
94.               
               CONTINUED: (2) 
                                 PETER
               What are you talking about? 
                                            LISA
               I just told him that to make it interesting. Anyway, we'll 
               probably have a baby eventually. You won't say anything to 
               Johnny, will you? 
                                          MICHELLE
               (MICHELLE PUTS HER HAND ON HER FOREHEAD.) 
               This is just getting worse and worse. 
                                 PETER
               I feel like I'm sitting on an atomic bomb waiting for it to 
               go off. 
                                          MICHELLE
               Me too. There's no simple solution to this. 
                                            LISA
               Don't worry. You guys worry entirely too much about me. 
                                          MICHELLE
               Lisa, we're not worried about you, we are worried about 
               Johnny. You don't understand the psychological impact of what 
               you are doing here. You're hurting yourself, you are hurting 
               OUR friendship. 
                                 PETER
               Actually it's more like a thermonuclear bomb I'm sitting on, 
               using the primary fission reaction from the atomic bomb I was 
               previously sitting on to compress and ignite a secondary 
               hydrogen based fusion reaction. 
                                            LISA
               I am not responsible for Johnny. I'm through with that. I'm 
               changing, the whole world's changing. I have the right, don't 
               I? People are changing all the time. I have to think about my 
               future. What's it to you? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
95.               
               CONTINUED: (3) 
                                 PETER
               This is going to pull us all down, it's going to shake up our 
               group of friends. It's going to destroy our friendship Lisa, 
               it's going to destroy everything, just like in that movie, 
               Dr. Strangelove. Except, I don't think Mark really loves you. 
                                            LISA
               (LISA STANDS UP.) 
               I don't want to talk about it! 
                                          MICHELLE
               Lisa, you are going to have to face it. I for one, am going 
               to have a hard time forgiving you if you don't. 
                                            LISA
               (LISA YELLS SO ALL CAN HEAR.) 
               Hey everybody, let's go inside and eat some cake! 
               (THE CROWD CHEERS AND LISA WALKS OFF WITH PETER AND 
               MICHELLE.) 
                                          MICHELLE
               I don't understand you Lisa. 
                                 PETER
               Women. They're all the same. 
               END SCENE 
               SCENE 26
               PEOPLE ARE ENJOYING THE CAKE. 
                                            BRAN
               Lisa looks hot tonight. 
               (JOHNNY IS TALKING TO CLAUDETTE AND HE KISSES HER ON THE 
               CHEEK AS THEY ARE LAUGHING. LISA IS BY THE COFFEE TABLE 
               TALKING WITH PETER, BILLY, AND MICHELLE. MARK APPROACHES THIS 
               GROUP, AND HE IS TIPSY.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
96.               
               CONTINUED: 
                                            MARK
               Come on, who's baby is it Lisa? Is it mine? 
                                            LISA
               (SHE'S LOOKING VERY ANGRY.) 
               No, of course not. 
                                            MARK
               (MARK STEPS CLOSER TO LISA AND PUTS HIS HAND ON HER ARM.) 
               How can you be sure anyway? Are you sure it's not mine? 
                                            LISA
               (SHE'S LOOKING VERY ANGRY.) 
               Don't ask me any stupid questions! 
                                            MARK
               (MARK HOLDS LISA'S ARM VERY TIGHTLY.) 
               Who the hell do you think you are!? 
                                            LISA
               (LISA SLAPS HIM WITH HER OTHER HAND ON THE FACE.) 
               Just shut up! 
                                           JOHNNY
               (JOHNNY SEES WHAT IS HAPPENING AND APPROACHES THEM.) 
               What's going on here? 
                                            MARK
               You really don't know, do you? 
                                            LISA
               He hurt my arm. 
               (SHE IS WHINING.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
97.               
               CONTINUED: (2) 
                                           JOHNNY
               I know more than you think I do, Mark. 
                                            MARK
               What's that supposed to mean? 
                                           JOHNNY
               Precisely what I said. That's why I chose the words. 
                                            MARK
               You don't know shit! 
                                           JOHNNY
               (JOHNNY IS VERY ANGRY) 
               What do you want from me? What do you want from me!!!! 
                                            MARK
               I want you to just disappear, you little twerp. 
                                           JOHNNY
               (JOHNNY PUNCHES MARK IN THE SHOULDER.) 
               You leave Lisa alone, prick. 
                                            MARK
               (MARK HITS JOHNNY IN THE FACE. JOHNNY RETURNS THE BLOW. THEY 
               END UP ON THE FLOOR WRESTLING AND HITTING EACH OTHER.) 
                                            LISA
               (LISA SCREAMS..........) 
               Stop! Stop! Stop! Peter! Michelle! Help!!! Help!!!.... 
               (LISA, PETER AND MICHELLE TRY TO PULL THEM A PART. SEVERAL 
               OTHER GUYS HELP LIFT THEM TO THEIR FEET AND HOLD THEM.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
98.               
               CONTINUED: (3) 
                                 PETER
               (PETER GRABS A BUCKET OF WATER AND ICE, AND POURS IT ON 
               JOHNNY AND MARK. THE GUYS WHO ARE HOLDING MARK AND JOHNNY 
               ALSO GET WET, AND THEY START LAUGHING AND SHOUTING AT PETER.) 
                                            MARK
               Knock it off Peter! What are you doing, are you crazy? 
                                 BILLY
               Peter can't be crazy! He's an expert psychologist! 
               (BILLY TURNS TOWARD PETER.) 
               Hey Peter, What's the difference between a psychologist and a 
               duck? 
                                 PETER
               I don't know. What? 
                                 BILLY
               One's a quack, the other's a duck. 
                                           JOHNNY
               The fight's over folks, everything's fine. 
               (JOHNNY STICKS OUT HIS HAND TO SHAKE MARK'S HAND.) 
               Sorry about that Mark. 
                                            MARK
               Yeah, yeah. Me too. 
                                           JOHNNY
               Lisa, can we have a big mop here? 
               (LISA GOES TO THE KITCHEN TO GET A MOP. PEOPLE START THROWING 
               ICE AT EACH OTHER AND LAUGHING. THE PARTY GOES ON WITH PEOPLE 
               TALKING, DRINKING AND EATING.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
99.               
               CONTINUED: (4) 
                                            LISA
               (LISA IS MOPPING THE FLOOR.) 
               You guys knock it off. You're just making more work for me. 
                                           JOHNNY
               (JOHNNY GOES TO THE BATHROOM AND COMES OUT WITH A STACK OF 
               TOWELS.) 
               Towels, anyone? 
               (SEVERAL GUYS TAKE TOWELS AND WIPE THEIR FACES AND HAIRS, AND 
               OTHERS SHOUT.) 
                                            MARK
               Yeah, I'll take one, maybe a couple. Maid service, thank 
               goodness. 
               (JOHNNY PUTS ON A HEAVY METAL MUSIC AND THE MOOD CHANGES TO 
               FAST DANCING.) 
               END SCENE 
               SCENE 27
               AFTER A WHILE LISA APPROACHES MARK TO DANCE. THEY ARE HOLDING 
               HANDS WHILE DANCING, STARING INTO EACH OTHER'S EYES WITH 
               SEDUCTIVE EXPRESSIONS, OFF AND ON TOUCHING EACH OTHER'S 
               SHOULDERS, HIPS AND KNEES. SOON, JOHNNY NOTICES AND 
               APPROACHES THEM.) 
                                           JOHNNY
               What are you doing? 
                                            LISA
               None of your business. 
                                           JOHNNY
               You are my future wife. What the heck are you doing? 
                                            MARK
               Leave her alone, man. She doesn't want to talk to you. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
100.               
               CONTINUED: 
                                           JOHNNY
               (VERY ANGRILY) 
               Since when do you give me orders! 
                                            MARK
               Since Lisa changed her mind about you. Wake up man. What 
               planet are you on? 
                                           JOHNNY
               I think you should leave right now. 
                                            LISA
               Don't spoil it, we were just having fun. 
                                            MARK
               (MARK POKES JOHNNY SLIGHTLY IN HIS SHOULDER.) 
               Don't worry about it, man. Everything's going to be alright. 
                                           JOHNNY
               Don't touch me you stupid motherfucker. Leave my girl alone. 
               (JOHNNY GRABS MARK AROUND HIS NECK AND PUSHES HIM BACK TO THE 
               WALL. MARK FORCES HIS HANDS BETWEEN JOHNNY'S ARMS AND BREAKS 
               JOHNNY'S GRIP, GRABS ONE OF JOHNNY'S ARMS AND TWISTS IT 
               BEHIND JOHNNY'S BACK. JOHNNY LEANS FORWARD AND BREAKS MARK'S 
               GRIP AND WHIRLS AROUND WITH A HIGH JUMPING REVERSE ROUNDHOUSE 
               DRAGON KICK TO THE SIDE OF MARK'S HEAD. AT THE SAME TIME LISA 
               TRIES TO GET BETWEEN THEM SCREAMING.) 
                                            LISA
               Stop! Stop! Why are you acting like children? Both of you are 
               ruining the party. 
               (SEVERAL GUYS GRAB MARK AND JOHNNY AND PULL THEM BACK AWAY 
               FROM EACH OTHER AND HOLD THEM. AT THE SAME TIME MARK AND 
               JOHNNY AND THE OTHER GUYS ARE SHOUTING AT EACH OTHER. 
               MICHELLE AND A FEW GIRLS TALK TO LISA TO CALM HER DOWN. 
               EVERYBODY IS TALKING AT ONCE.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
101.               
               CONTINUED: (2) 
                                            MARK
               You son of a bitch dirty scum! If you keep your girl 
               satisfied, she wouldn't come to me! 
                                           JOHNNY
               Get out! If I ever see you again I will kill you. I will 
               break every bone in your body, you son of a bitch asshole! 
OTHER GUYS
               (THE OTHER GUYS ARE FORCING MARK TOWARD THE DOOR AND 
               SHOUTING.) 
               What are you doing, are you nuts? 
               You're supposed to be best friends. 
               Break it up, it's over. 
               Cool it you guys. 
               Mark, go home and take a cold shower. 
               They are so stupid. 
                                            MARK
               (MARK IS SHOUTING FROM THE HALLWAY.) 
               You couldn't kill me if you tried. 
                                           JOHNNY
               You bastard! You betray me! You are not good, you are just a 
               wimp!!! I'll get you, you just wait!! You chicken!!! CHIP!!! 
               CHIP!!!! CHIP!!!! CHIP!!!!! 
               (CHICKEN NOISES.) 
                                            MARK
               (MARK'S SHOUTING THINGS DOWN THE HALLWAY.) 
               Your ass is grass, and I'm the lawnmower!!! Go pee on an 
               electric fence!! 
                                           JOHNNY
               Remember Mark!! He who laughs last, laughs last! So go ahead, 
               I dare you to say something in reply to me! I double dare 
               you!! But I know you won't because you're too afraid!!! 
               (MARK STOMPS AWAY, FURIOUS AND AFRAID.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
102.               
               CONTINUED: (3) 
                                 PETER
               Chill out Johnny, it's over. 
                                           JOHNNY
               It's not over! Everybody betray me. I'm fed up with this 
               world! 
               (JOHNNY PICKS UP A PARTY GLASS AND THROWS IT AT THE FULL 
               LENGTH MIRROR WHICH SHATTERS INTO SMALL PIECES. SOME GIRLS 
               SCREAM AND BACK AWAY WITH SHOCKED EXPRESSIONS. JOHNNY WHIRLS 
               AROUND AND STOMPS ANGRILY INTO THE BATHROOM AND SLAMS THE 
               DOOR. IMMEDIATELLY THERE ARE MORE SOUNDS OF CRASHING GLASS 
               COMING FROM THE BATHROOM. LISA GOES TO THE BATHROOM AND TRIES 
               TO OPEN THE DOOR, BUT IT'S LOCKED. SHE RATTLES THE DOORNOB 
               AND SCREAMS AT JOHNNY. YELLING.) 
                                            LISA
               Open the door! Come out Johnny! 
               (LISA BANGS ON THE DOOR WITH THE HEEL OF HER HAND. MICHELLE 
               COMES OVER TO LISA.) 
                                          MICHELLE
               Calm down Lisa. I never saw him like this. 
                                 PETER
               (PETER COMES OVER.) 
               Lisa, it's getting late. I'm going to have to go soon. But, I 
               don't want to leave you like this. 
                                            LISA
               I'm alright. This is between Johnny and me anyway. 
                                 BILLY
               Good idea Peter. The party's over. Besides, it was a big 
               Lame­O anyway. 
               (HE MAKES "L" THEN "O" SIGNS WITH HIS HANDS.) 
               I'm also leaving. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
103.               
               CONTINUED: (4) 
                                            BRAN
               Me too. 
               (BILLY AND BRAN LEAVE.) 
                               CLAUDETTE
               (CLAUDETTE, WEARING AN APRON, IS SWEEPING UP BROKEN MIRROR 
               GLASS AND DISPOSING OF IT.) 
               Don't worry Lisa, I'll stay here and help you. 
OTHER PEOPLE
               (OTHER PEOPLE TAKE THE HINT AND START GETTING READY TO LEAVE. 
               SEVERAL WOMEN PICK UP EMPTY BOTTLES AND GLASSES AND CARRY 
               THEM TO THE KITCHEN. SOME OTHER PEOPLE GATHER IN A CORNER AND 
               WHISPER AMONG THEMSELVES, LAUGHING AND FINISHING THEIR 
               DRINKS. GRADUALLY THE PEOPLE LEAVE, THANKING LISA FOR 
               INVITING THEM.) 
               See you later. 
               Bye Johnny. 
               See you Johnny. 
               See you Lisa. 
               Happy birthday. 
               Are you going to be alright Lisa? 
               See you everybody. 
               Bye. 
                                            LISA
               Don't worry about me, I'll be fine. 
               See you later. 
               See you later. 
               See you later. 
                                 PETER
               (PETER KNOCKS ON THE BATHROOM DOOR) 
               Johnny, I'm leaving now. I want to shake your hand. 
                                           JOHNNY
               Go on Peter, I'll talk to you tomorrow. Thanks for 
               everything. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
104.               
               CONTINUED: (5) 
                                 PETER
               I want to talk to you before I leave. 
               (JOHNNY DOESN'T RESPOND. PETER TURNS TO LISA.) 
                                 PETER
               He's pretty stubborn, isn't he? 
                                            LISA
               We'll work it out, you can go now. 
                                 PETER
               Alright, you call me anytime if you need me. See you later. 
               (PETER GIVES A LITTLE KISS ON LISA'S CHEEK AND TURNS TO 
               MICHELLE.) 
                                 PETER
               See you next Friday, Michelle. 
                                          MICHELLE
               Sure Peter. You take care. Bye. 
               (PETER GOES OUT THE DOOR.) 
                                          MICHELLE
               Lisa, can I help you clean up? 
                                            LISA
               No thanks Michelle. Mom's going to do it. Thanks for all your 
               help. 
                                          MICHELLE
               Where is your mom? I don't see her. 
                                            LISA
               She's in the kitchen, if I know my mom. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
105.               
               CONTINUED: (6) 
                               CLAUDETTE
               (FROM THE KITCHEN.) 
               I heard that, Lisa. Get your pretty little buns in here and 
               help. 
                                          MICHELLE
               Well, I guess I'll leave it to the family. 
                                            LISA
               Bye, Bye, see you later, Michelle. Thanks for your help. 
                                          MICHELLE
               Bye, Lisa. It was my pleasure. 
               (MICHELLE GOES OUT THE DOOR.) 
                                            LISA
               (LISA GOES TO THE KITCHEN.) 
               Mom, what am I going to do? He won't come out of the 
               bathroom. 
                               CLAUDETTE
               Don't bother me about it. I'm not talking to him. He is 
               prick. He won't even help a poor old dying lady. 
                                            LISA
               Oh, never mind. 
               (LISA GOES TO THE BATHROOM DOOR AND RATTLES THE NOB.) 
               Johnny! Hey, Johnny! 
                                           JOHNNY
               I won't come out until she leaves. 
                                            LISA
               Why are you being such a baby? 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
106.               
               CONTINUED: (7) 
                               CLAUDETTE
               (CLAUDETTE COMES OUT OF THE KITCHEN DRYING HER HANDS ON A 
               KITCHEN TOWEL.) 
               Don't worry!!!! I'm leaving!!!!! 
               (SHE IS TALKING LOUD ENOUGH FOR JOHNNY TO HEAR. SHE FOLDS THE 
               TOWEL AND TAKES OFF HER APRON AND FOLDS IT.) 
                                            LISA
               I'm glad you could come mom, thanks for your help. 
                               CLAUDETTE
               Don't mention it dear. Call me tomorrow and we'll see how you 
               feel. 
                                            LISA
               I'll get your coat. 
               (LISA HELPS HER MOTHER WITH HER COAT, AND CLAUDETTE GOES OUT 
               THE DOOR.) 
                               CLAUDETTE
               Good night dear, sweet dreams. Be good to Johnny. 
               (TO JOHNNY.) 
               Good night Johnny! 
                                            LISA
               I'll try. Good night mom. 
               (LISA GOES TO THE BATHROOM DOOR.) 
                                            LISA
               Come out now Johnny, she's gone. 
                                           JOHNNY
               In a few minutes bitch. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
107.               
               CONTINUED: (8) 
                                            LISA
               Who are you calling a bitch? 
                                           JOHNNY
               You and your stupid mother. 
                                            LISA
               (LISA GOES OVER TO THE PHONE AND PUNCHES NUMBERS, THEN WALKS 
               HOLDING IT TO HER EAR AS FAR INTO THE KITCHEN AS THE CORD 
               WILL STRETCH. ) 
               Hi Mark, I need to talk to you. Don't pay any attention to 
               Johnny, he's being a big baby. You know I love you very much. 
               You're the sparkle of my life. I can't live without you. I 
               love you. 
                                            MARK
               Why don't you ditch this creep. I don't like him anymore. 
                                            LISA
               I know, he's not worth it. Why don't I come up there and be 
               with you? 
                                            MARK
               Sure baby, come on up. I want your body. 
                                            LISA
               You got it. I'm on my way. Bye. 
               (LISA HANGS UP.) 
                                           JOHNNY
               (ANGRILY, JOHNNY COMES OUT OF THE BATHROOM.) 
               Who were you talking to? 
                                            LISA
               (LISA TAKES A CANVAS BAG OUT OF THE CLOSET.) 
               Nobody. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
108.               
               CONTINUED: (9) 
                                           JOHNNY
               (JOHNNY WALKS TO THE ANSWERING MACHINE AND PUSHES SOME 
               BUTTONS.) 
               We'll just see about that! 
VOICE OF LISA
               Hi Mark, I need to talk to you. Don't pay any attention to 
               Johnny, he's being a big baby. You know I love you very much. 
               You're the sparkle of my life. I can't live without you. I 
               love you. 
                                           JOHNNY
               (JOHNNY PRESSES THE PAUSE BUTTON.) 
               You little tramp! how could you do this to me! I gave you 
               seven years of my life! Let's see what else we have on this 
               tape! 
                                            LISA
               No stop! You little prick! I put up with you for seven years! 
               You think you are an angel, but you're just like everybody. 
                                           JOHNNY
               I treat you like a princess and you stabbed me in the back. I 
               love you and I did everything to please you, and now you 
               betray me...how could you love him!! Let's hear the tape. 
               (JOHNNY PRESSES A BUTTON.) 
VOICE OF MARK
               Why don't you ditch this creep. I don't like him anymore. 
VOICE OF LISA
               I know, he's not worth it. Why don't I come up there and be 
               with you? 
VOICE OF MARK
               Sure baby, come on up. I want your body. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
109.               
               CONTINUED: (10) 
VOICE OF LISA
               You got it. I'm on my way. Bye. 
                                           JOHNNY
               (JOHNNY PICKS UP THE MACHINE AND YANKS IT TO BREAK THE WIRE 
               AND THROWS IT AGAINST THE WALL.) 
               Everybody betray me! I don't have a friend in the world! 
                                            LISA
               I'm leaving you Johnny. 
               (LISA GOES TO THE BATHROOM WITH HER BAG, THROWS A FEW THINGS 
               INTO IT AND RUNS OUT THE DOOR WITH IT.) 
                                           JOHNNY
               (JOHNNY IS YELLING WHILE LISA IS SLAMMING THE DOOR.) 
               Get out! Get out! Get out of my life!!! 
               (JOHNNY PICKS UP THE TV AND THROWS IT THROUGH THE WINDOW. 
               THERE'S A BIG NOISE AND CRASH OUTSIDE THE WINDOW. HE YELLS.) 
                                           JOHNNY
               Screw the whole world! I don't need them! 
               (MORE GLASS SHATTERS. JOHNNY TIPS A CHAIR OVER, THEN THE SOFA 
               AND GRABS A LAMP AND THROWS IT OUT THE BROKEN WINDOW. WE HEAR 
               A DISTANT CRASH. HE CLEARS OFF THE SHELF WITH HIS HANDS. 
               BOOKS AND OTHER ITEMS FALL ON THE FLOOR. WHATEVER HE SEES HE 
               THROWS AGAINST THE WALLS.) 
NEIGHNOR #1.
               (SOMEONE BANGS ON THE FRONT DOOR.) 
               What's going on in there? Open up! open up! Are you okay? 
               (THERE IS MORE BANGING ON THE DOOR.) 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
110.               
               CONTINUED: (11) 
                                           JOHNNY
               (JOHNNY GOES INTO THE CLOSET AND THROWS OUT EVERYTHING HE 
               SEES AND FINDS A WOODEN BOX ABOUT THE SIZE OF A SHOE BOX. HE 
               TRIES TO PULL IT OPEN, BUT HE CAN'T. HE THROWS IT TO THE 
               FLOOR BUT IT DOESN'T OPEN. HE KICKS IT, BUT IT DOESN'T OPEN. 
               HE PULLS A PIECE OF METAL FROM THE BOTTOM OF THE CHAIR AND 
               PRIES OPEN THE PADLOCK AND SUCCEEDS. HE OPENS THE BOX AND 
               TAKES OUT A GUN. HE IS CRYING.) 
               Why? Why? Why? Why is this happening to me! Why? Why is this 
               happening to me! I can't deal with this any more! It's over! 
               It's over! 
               (SUDDENLY HE STARES INTO THE CLOSET. HE REACHES IN AND PULLS 
               OUT A SEXY NIGHTGOWN. HE HOLDS IT AT ARM'S LENGTH.) 
               You tramp! You tramp! 
               (HE THROWS IT DOWN ON THE FLOOR. HE REACHES IN AND PULLS OUT 
               MORE OF LISA'S CLOTHES AND THROWS THEM ON THE FLOOR. HE LIES 
               ON THE CLOTHES, UNZIPPING HIS ZIPPER. HE IS BREATHING HARD 
               AND WRITHING WITH PELVIC THRUSTS.) 
               (WHEN HE FINISHES, HE SITS UP AND PICKS UP THE GUN. HIS 
               FINGER IS ON THE TRIGGER. TEARS ARE FLOWING DOWN HIS CHEEKS. 
               HE THROWS THE GUN AWAY FROM HIM. HE IS CRYING WITH HIS FACE 
               IN HIS HANDS. AFTER A WHILE, HE CRAWLS TO THE GUN, STILL 
               CRYING OUT LOUD. HE REACHES FOR THE GUN WITH HIS HAND 
               SHAKING. HE PICKS IT UP AND POINTS IT AT THE MIDDLE OF HIS 
               FOREHEAD.) 
                                           JOHNNY
               God forgive me. 
               (JOHNNY PULLS THE TRIGGER. HE COLLAPSES ON THE FLOOR 
               GROANING. HE IS DEAD.) 
                                            LISA
               (LISA OPENS THE DOOR TO THE APARTMENT. MARK RUSHES IN PAST 
               HER AND KNEELS DOWN BESIDE JOHNNY'S BODY. ALSO SEVERAL 
               NEIGHBORS COME IN. LISA STANDS BY THE DOOR WITH AN EXPRESSION 
               OF HORROR AND HER ARMS FOLDED.) 
NEIGHNOR #1.
               Somebody call the police! 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
111.               
               CONTINUED: (12) 
NEIGHNOR #2.
               Don't anybody touch anything! Call an ambulance! 
               (ONE PERSON LEAVES THE ROOM TO CALL.) 
                                            MARK
               Johnny, open your eyes. Wake up! 
               (MARK HOLDS JOHNNY'S ARM AND HIS HEAD.) 
                                            LISA
               Is he dead Mark? Is he dead? 
                                            MARK
               (MARK IS VERY EMOTIONAL. HE TOUCHES THE SIDE OF JOHNNY'S 
               NECK.) 
               Yes he's dead! Yes he's dead!!! 
               (HE KISSES JOHNNY ON THE FOREHEAD.) 
                                            LISA
               (LISA PUTS HER HAND OVER HER EYES AND SAYS.) 
               Oh! Oh my God! 
               (MARK STANDS BESIDE LISA AND HOLDS HER TIGHTLY.) 
                                            LISA
               Oh well, the insurance is paid up, $ 100,000.00 
                                            MARK
               (MARK STANDS BACK AWAY FROM LISA.) 
               You're thinking of insurance at a time like this!? 
                                            LISA
               Don't you see? We're free to be together. 
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
112.               
               CONTINUED: (13) 
                                            MARK
               (MARK PUSHES LISA AGAINST THE WALL.) 
               You tramp! You killed him, you're the cause of all of this. 
               Go to hell! I don't need your dirty money. I don't love you. 
               As far as I'm concerned you can drop off the Earth. 
               (PAUSE.) 
               Get out of my life! get out of my life Lisa! 
               (MARK KNEELS AGAIN BESIDE JOHNNY, CRYING. SIRENS CAN BE HEARD 
               IN THE DISTANCE.) 
THE END
 THE ROOM by Tommy P. Wiseau Copyright ©, 1999   Copyright ©, 2001­15
   Copyright ©, 2000   ALL RIGHT RESERVED
   */ 
