using lab25.Core;

static void Separator(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('=', 60));
}

static string Shorten(string s, int max = 60)
{
    if (s.Length <= max) return s;
    return s.Substring(0, max) + "...";
}

string input = "Hello from lab25! This is sample data for processing.";

//
// SCENARIO 1 — Full integration
//
Separator("SCENARIO 1: Full integration (ConsoleLogger + Encrypt)");

LoggerManager.Instance.Initialize(new ConsoleLoggerFactory());

var context1 = new DataContext(new EncryptDataStrategy());
var publisher1 = new DataPublisher();
var observer1 = new ProcessingLoggerObserver();
observer1.Subscribe(publisher1);

LoggerManager.Instance.Log("LoggerManager initialized with ConsoleLoggerFactory.");
LoggerManager.Instance.Log($"Current strategy: {context1.CurrentStrategyName}");

var processed1 = context1.ProcessData(input);
LoggerManager.Instance.Log($"Processed data: {Shorten(processed1)}");

publisher1.PublishDataProcessed(processed1);

Console.WriteLine("Visual check: console has messages from logger + observer.");

//
// SCENARIO 2 — Dynamic logger change
//
Separator("SCENARIO 2: Dynamic logger change (Console -> File)");

LoggerManager.Instance.Initialize(new ConsoleLoggerFactory());

var context2 = new DataContext(new EncryptDataStrategy());
var publisher2 = new DataPublisher();
var observer2 = new ProcessingLoggerObserver();
observer2.Subscribe(publisher2);

var processed2a = context2.ProcessData(input);
LoggerManager.Instance.Log($"First run (console): {Shorten(processed2a)}");
publisher2.PublishDataProcessed(processed2a);

// Change logger factory dynamically
LoggerManager.Instance.SetFactory(new FileLoggerFactory());

var processed2b = context2.ProcessData(input + " second run");
LoggerManager.Instance.Log($"Second run (file): {Shorten(processed2b)}");
publisher2.PublishDataProcessed(processed2b);

Console.WriteLine("Visual check: open log.txt -> there must be logs from scenario 2.");

//
// SCENARIO 3 — Dynamic strategy change
//
Separator("SCENARIO 3: Dynamic strategy change (Encrypt -> Compress)");

LoggerManager.Instance.Initialize(new ConsoleLoggerFactory());

var context3 = new DataContext(new EncryptDataStrategy());
var publisher3 = new DataPublisher();
var observer3 = new ProcessingLoggerObserver();
observer3.Subscribe(publisher3);

LoggerManager.Instance.Log($"Strategy BEFORE: {context3.CurrentStrategyName}");
var processed3a = context3.ProcessData(input);
LoggerManager.Instance.Log($"Encrypt result: {Shorten(processed3a)}");
publisher3.PublishDataProcessed(processed3a);

// Change strategy dynamically
context3.SetStrategy(new CompressDataStrategy());

LoggerManager.Instance.Log($"Strategy AFTER: {context3.CurrentStrategyName}");
var processed3b = context3.ProcessData(input);
LoggerManager.Instance.Log($"Compress result: {Shorten(processed3b)}");
publisher3.PublishDataProcessed(processed3b);

Separator("DONE");
