public class PaymentHistoryController : Controller
{
    private readonly IRepository<PaymentHistory> _paymentHistoryRepository;

    public PaymentHistoryController(IRepository<PaymentHistory> paymentHistoryRepository)
    {
        _paymentHistoryRepository = paymentHistoryRepository;
    }

    public IActionResult Index()
    {
        return View(_paymentHistoryRepository.GetAll());
    }

    public IActionResult Details(int id)
    {
        PaymentHistory paymentHistory = _paymentHistoryRepository.GetById(id);

        if (paymentHistory == null)
        {
            return NotFound();
        }

        return View(paymentHistory);
    }

    public IActionResult PayBill(int userId, int payeeId, decimal amount)
    {
        var user = _userRepository.GetById(userId);
        var payee = _payeeRepository.GetById(payeeId);

        var paymentHistory = new PaymentHistory
        {
            CustomerId = user.Id,
            PayeeId = payee.Id,
            PaymentDate = DateTime.Now,
            Amount = amount
        };

        _paymentHistoryRepository.Add(paymentHistory);
        _paymentHistoryRepository.SaveChanges();

        return RedirectToAction("Index");
    }

}
