public class PayeeController : Controller
{
    private readonly IRepository<Payee> _payeeRepository;

    public PayeeController(IRepository<Payee> payeeRepository)
    {
        _payeeRepository = payeeRepository;
    }

    public IActionResult Index()
    {
        return View(_payeeRepository.GetAll());
    }

    public IActionResult Details(int id)
    {
        Payee payee = _payeeRepository.GetById(id);

        if (payee == null)
        {
            return NotFound();
        }

        return View(payee);
    }

    public IActionResult AddPayee()
    {
        var name = Request.Form["name"];
        var address = Request.Form["address"];
        var city = Request.Form["city"];
        var state = Request.Form["state"];
        var zipCode = Request.Form["zipCode"];
        var accountNumber = Request.Form["accountNumber"];

        var payee = new Payee
        {
            PayeeName = name,
            PayeeAddress = address,
            PayeeCity = city,
            PayeeState = state,
            PayeeZipCode = zipCode,
            PayeeAccountNumber = accountNumber
        };

        _payeeRepository.Add(payee);
        _payeeRepository.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult UpdatePayee(int payeeId)
    {
        var name = Request.Form["name"];
        var address = Request.Form["address"];
        var city = Request.Form["city"];
        var state = Request.Form["state"];
        var zipCode = Request.Form["zipCode"];
        var accountNumber = Request.Form["accountNumber"];

        var payee = _payeeRepository.GetById(payeeId);
        payee.PayeeName = name;
        payee.PayeeAddress = address;
        payee.PayeeCity = city;
        payee.PayeeState = state;
        payee.PayeeZipCode = zipCode;
        payee.PayeeAccountNumber = accountNumber;

        _payeeRepository.Update(payee);
        _payeeRepository.SaveChanges();

        return RedirectToAction("Index");
    }

}
