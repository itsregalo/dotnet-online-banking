public class AccountController : Controller
{
    private readonly IRepository<Account> _accountRepository;

    public AccountController(IRepository<Account> accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public IActionResult Index()
    {
        return View(_accountRepository.GetAll());
    }

    public IActionResult Details(int id)
    {
        Account account = _accountRepository.GetById(id);

        if (account == null)
        {
            return NotFound();
        }

        return View(account);
    }

    public IActionResult Register()
    {
        var name = Request.Form["name"];
        var email = Request.Form["email"];
        var password = Request.Form["password"];

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        _userRepository.SaveChanges();

        return RedirectToAction("Index");
    }


    public IActionResult Login()
    {
        var email = Request.Form["email"];
        var password = Request.Form["password"];

        var user = _userRepository.FindByEmail(email);

        if (user != null && user.Password == password)
        {
            HttpContext.Session.SetItem("UserId", user.Id);
            return RedirectToAction("Index");
        }

        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Update()
    {
        var userId = int.Parse(Request.Form["userId"]);
        var name = Request.Form["name"];
        var email = Request.Form["email"];
        var password = Request.Form["password"];

        var user = _userRepository.GetById(userId);
        user.Name = name;
        user.Email = email;
        user.Password = password;

        _userRepository.Update(user);
        _userRepository.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult GetBalance(int userId)
    {
        var user = _userRepository.GetById(userId);
        var balance = user.Accounts.First().Balance;

        return Json(balance);
    }

    public IActionResult GetDepositWithdrawHistory(int userId)
    {
        var user = _userRepository.GetById(userId);
        var history = user.Accounts.First().AccountActivities;

        return Json(history);
    }





    
}

