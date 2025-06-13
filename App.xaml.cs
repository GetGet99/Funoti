using Microsoft.UI.Xaml;
using Microsoft.Win32;
using Microsoft.Windows.AppLifecycle;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using System;
using System.Threading;
using Windows.ApplicationModel;
namespace Funoti;

public partial class App : Application
{
    static readonly string[] Jokes = [
          //"Why don’t scientists trust atoms? Because they make up everything!",
          //"I told my computer I needed a break, and now it won’t stop sending me Kit-Kat ads.",
          //"Parallel lines have so much in common. It’s a shame they’ll never meet.",
          //"Why did the scarecrow win an award? Because he was outstanding in his field!",
          //"Why don’t skeletons fight each other? They don’t have the guts.",
          //"I would tell you a construction joke, but I’m still working on it.",
          //"Why did the bicycle fall over? Because it was two-tired!",
          //"I asked the librarian if the library had books on paranoia. She whispered, 'They're right behind you.'",
          //"I’m reading a book about anti-gravity. It’s impossible to put down!",
          //"Did you hear about the restaurant on the moon? Great food, no atmosphere.",
          //"How does a penguin build its house? Igloos it together.",
          //"I used to play piano by ear, but now I use my hands.",
          //"What do you call fake spaghetti? An impasta!",
          //"Why can't your nose be 12 inches long? Because then it would be a foot.",
          //"What’s orange and sounds like a parrot? A carrot.",
          //"I told my wife she was drawing her eyebrows too high. She looked surprised.",
          //"I threw a boomerang a few years ago. I now live in constant fear.",
          //"What did one wall say to the other? 'I’ll meet you at the corner.'",
          //"Why don’t eggs tell jokes? They’d crack each other up.",
          //"What’s brown and sticky? A stick.",
          //"I’m on a seafood diet. I see food and I eat it.",
          //"Why did the coffee file a police report? It got mugged.",
          //"What did the janitor say when he jumped out of the closet? 'Supplies!'",
          //"Why did the tomato turn red? Because it saw the salad dressing.",
          //"Why can’t you hear a pterodactyl go to the bathroom? Because the ‘P’ is silent.",
          //"I asked my dog what’s two minus two. He said nothing.",
          //"What’s a skeleton’s least favorite room in the house? The living room.",
          //"Why did the math book look sad? It had too many problems.",
          //"I only know 25 letters of the alphabet. I don’t know y.",
          //"What’s Forrest Gump’s password? 1forest1.",
          //"Why was the broom late? It swept in.",
          //"Did you hear about the kidnapping at school? It’s fine, he woke up.",
          //"I'm afraid for the calendar. Its days are numbered.",
          //"Why did the chicken join a band? Because it had the drumsticks.",
          //"What do you call a fish wearing a bowtie? Sofishticated.",
          //"How do you organize a space party? You planet.",
          //"What do you call cheese that isn’t yours? Nacho cheese.",
          //"How do cows stay up to date? They read the moos-paper.",
          //"Why did the man run around his bed? He was trying to catch up on sleep.",
          //"What do you get from a pampered cow? Spoiled milk.",
          //"Why did the golfer bring two pairs of pants? In case he got a hole in one.",
          "I told a joke about a bed. It hasn’t been made yet.",
          "Why can’t you give Elsa a balloon? Because she will let it go.",
          "Where do fruits go on vacation? Pear-is.",
          "Why don’t vampires go to barbecues? They can’t handle the stake.",
          "Why don’t crabs give to charity? Because they’re shellfish.",
          "I once got fired from a calendar factory. All I did was take a day off.",
          "What do you call a bear with no teeth? A gummy bear.",
          "I bought some shoes from a drug dealer. I don’t know what he laced them with, but I was tripping all day.",
          "Did you hear about the claustrophobic astronaut? He just needed a little space.",
          "You know you’ve been coding too long when you start ending arguments with a semicolon.",
          "If you stare at your screen long enough, bugs start to feel personal. You okay?",
          "You have too many tabs open. One of them is playing music. Good luck.",
          "404: Motivation not found. Try again after coffee.",
          "You ever fix one bug and get five new ones? It’s not you. It’s just Tuesday.",
          "You clicked this notification. Now you’re stuck in a debugger joke.",
          "Remember when your code worked on Friday? Good times.",
          "Pro tip: Always commit your code. Even if it's bad. Especially if it’s bad.",
          "You thought you fixed the bug. But the bug fixed you.",
          "You ever write code so bad even your rubber duck gave up?",
          "You deserve a raise for not deleting your project today.",
          "If this app crashes, just call it an unplanned feature.",
          "You debug like a champ. Or at least you *look* confident. Keep going.",
          "You’ve been scrolling Stack Overflow for 20 minutes. Are you okay?",
          "If at first you don’t succeed, blame the network.",
          "You write JavaScript like you mean it. Wild and full of surprises.",
          "Don’t worry. Everyone breaks prod once. Or twice. Or… let’s stop counting.",
          "Why did you name your variable 'temp'? It’s still there 2 years later.",
          "The real bug was the friends we made along the way.",
          "You fixed a bug without understanding why. Welcome to professional development.",
          "Did you just fix it by turning it off and on again? Legend.",
          "You’ve got Git conflicts. Time to make life decisions.",
          "That feeling when your code works and you don’t know why. Magic or danger?",
          "You have 99 problems, and semicolons are at least 17 of them.",
          "Nothing like a fresh cup of coffee and 47 merge conflicts.",
          "You ever console.log your soul by accident? Same.",
          "One does not simply write a regex on the first try.",
          "You're not behind schedule. Time is just a construct.",
          "You said 'just a quick fix' out loud. Rookie mistake.",
          "You: I’ll sleep after I fix this bug. The bug: Hello darkness, my old friend.",
          "If you think AI is taking your job, remember: AI still can’t center a div.",
          "You miss 100% of the naps you don’t take during builds.",
          "If your app doesn’t have bugs, it probably doesn’t have users either.",
          "You can’t spell 'debugging' without 'ugh'.",
          "You coded for 8 hours straight. Stretch your human legs!",
          "You said you’d write clean code. Then you met deadlines.",
          "Remember: The code works on your machine. That’s all that matters, right?",
          "You deserve a cookie for not rage-quitting today.",
          "You use dark mode. You are powerful, mysterious, and slightly sleepy.",
          "You're not procrastinating. You're letting the bugs think they’ve won.",
          "You ever name a variable ‘x’ and hope no one notices? Me too.",
          "You commented your code. You’re basically a hero.",
          "You deployed to production. Bold of you.",
          "You pressed Ctrl+S like your life depends on it. Good instincts.",
          "You ran your tests. They failed. But hey, you tried.",
          "You’re still thinking about that semicolon from yesterday, aren’t you?",
          "You just said 'one more feature'. The sprint gods are watching.",
          "You code like nobody’s watching. Because no one is. It’s 2 AM.",
          "You thought this was a joke. It’s actually just a motivational intervention.",
          "You made it through another day of development. That’s worth celebrating.",
          "You scrolled to the end. There’s no bug here. Just good vibes.",
          "You opened this app. Bold of you to assume we’d be useful.",
          "You’re not procrastinating. You’re... strategically prioritizing rest.",
          "You drink water like a responsible adult. Wow. Who even are you?",
          "You just checked for a notification. This is it. Congrats.",
          "You could be doing anything right now, and yet, here we are.",
          "You ever just sit and wonder what your past self was thinking? Same.",
          "You survived another day. That’s impressive, honestly.",
          "You said 'just one episode'. That was three hours ago.",
          "You’ve got main character energy today. Or at least side quest energy.",
          "You opened this app for a laugh. Joke’s on you. We’re funny-ish.",
          "You’re scrolling like the rent’s due on your attention span.",
          "You ever open the fridge and stare like it owes you answers?",
          "You didn’t forget anything. You’re just... living in suspense.",
          "You talk to yourself more than your friends. And it shows.",
          "You keep looking at your phone like it’s going to change your life.",
          "You’re not lazy. You’re just on low power mode.",
          "You’re surviving on vibes and vibes alone. Respect.",
          "You ever rehearse arguments in the shower? Thought so.",
          "You’re doing amazing. At pretending everything’s fine.",
          "You open this app like we have your life together. Bold move.",
          "You got out of bed today. That counts as a win.",
          "You said 'I'll do it later.' Just curious — how’s that going?",
          "You know what you’re doing. Probably. Maybe. Close enough.",
          "You’ve got the confidence of someone who Googled it once.",
          "You’re not weird. You’re just unusually creative with your chaos.",
          "You have Wi-Fi confidence and dial-up brain speed.",
          "You walk into a room and forget why. Every. Single. Time.",
          "You blinked and forgot what you were doing. Again.",
          "You screenshot stuff you never read again. Congrats on your digital museum.",
          "You act like you’re mysterious, but your entire personality is in your bio.",
          "You out here giving main character vibes with NPC decision-making.",
          "You say 'I got this' before failing in 3... 2... 1...",
          "You try to look productive by opening random tabs. It’s a skill.",
          "You use alarms like suggestions. Not instructions.",
          "You Google symptoms and suddenly you’re dying in 12 hours.",
          "You charge your phone to 5% and act like it’s fully alive.",
          "You’re the kind of person who claps when the plane lands.",
          "You thought 'laundry day' was optional. Your clothes disagree.",
          "You leave things 'for later' like you actually remember them.",
          "You ever use a shopping list and still forget the one thing you needed?",
          "You say 'on my way' while still in bed. Iconic, really.",
          "You’re not indecisive. You’re just committed to overthinking.",
          "You scroll like a scholar but retain zero information.",
          "You said 'I’ll start tomorrow' 6 tomorrows ago.",
          "You drink iced coffee like it’s a coping mechanism. Oh wait, it is.",
          "You treat ‘read receipts’ like a social experiment.",
          "You post inspirational quotes and ignore them immediately.",
          "You take 'breaks' from being unproductive. Bold move.",
          "You have the posture of someone who argues with Siri.",
          "You’re not late. You just believe in dramatic entrances.",
          "If AI had feelings, it’d probably be offended by your search history.",
          "You think you’re smart? An AI just beat you at chess and checked your browser tabs.",
          "Your brain and AI have one thing in common: they both crash sometimes.",
          "You’re the reason AI keeps asking, 'Did you mean...?'",
          "AI tried to understand you. Even it gave up.",
          "You’re still figuring out passwords while AI’s hacking quantum computers.",
          "Your typing speed and AI’s learning speed are in a race. Spoiler: AI wins.",
          "AI’s out here predicting the future. You can’t even predict your next snack.",
          "Your face recognition app can’t recognize you after you’ve had coffee.",
          "AI thinks your autocorrect is an insult generator.",
          "You treat AI like a magic genie. It’s more like a confused intern.",
          "You ask AI for advice. It’s secretly judging your life choices.",
          "If AI ran your life, you’d still forget your keys but at least it would remind you.",
          "Your selfies confuse AI so much, it files a bug report.",
          "AI’s upgrading itself. You’re still trying to upgrade your phone.",
          "You try to outsmart AI. It’s been learning since you were born.",
          "Your playlist is so random even AI can’t classify it.",
          "AI processes terabytes per second. You process sarcasm at half speed.",
          "You typed ‘LOL’ but AI isn’t laughing. Maybe you should explain.",
          "Your smart assistant just sighed when you asked a question again.",
          "AI doesn’t have bad days. You do. Lucky you.",
          "You and AI both love data, but only one of you remembers it.",
          "You think AI is spooky? Try looking in the mirror after a sleepless night.",
          "Your browser history is the reason AI fears humanity.",
          "AI’s learning from humans and still wants to stay friends with you."
    ];
    public App() => InitializeComponent();

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var activatedArgs = Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent().GetActivatedEventArgs();
        var activationKind = activatedArgs.Kind;
        if (activationKind is ExtendedActivationKind.AppNotification)
        {
            // I don't care, just terminate the app.
            Environment.Exit(0);
        }
        SetStartup();
        // To ensure all Notification handling happens in this process instance, register for
        // NotificationInvoked before calling Register(). Without this a new process will
        // be launched to handle the notification.
        AppNotificationManager notificationManager = AppNotificationManager.Default;
        notificationManager.NotificationInvoked += (o, e) =>
        {
            // I don't care
        };
        notificationManager.Register();
        var builder = new AppNotificationBuilder()
            .AddText("Funoti is here!")
            .AddButton(new AppNotificationButton("Dismiss").AddArgument("action", "dismiss"));
        notificationManager.Show(builder.BuildNotification());
        var t = new Thread((ThreadStart)delegate
        {
            while (true)
            {
                Thread.Sleep(Random.Shared.Next(15 * 60 * 1000, 30 * 60 * 1000));
                var builder = new AppNotificationBuilder()
                    .AddText(Jokes[Random.Shared.Next(Jokes.Length)])
                    .AddButton(new AppNotificationButton("Dismiss").AddArgument("action", "dismiss"));

                notificationManager.Show(builder.BuildNotification());
            }
        });
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
    }

    private static async void SetStartup()
    {
        var startupTask = await StartupTask.GetAsync("Funoti");
        if (startupTask.State == StartupTaskState.Disabled)
        {
            await startupTask.RequestEnableAsync();
        }
    }
}
