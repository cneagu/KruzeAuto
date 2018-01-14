var SearchPagination = function (pageNumbers) {

    this.PaginationCard = function () {

        var pagNav = ""
        //<nav aria-label="Page navigation example">
        //    <ul class="pagination justify-content-center">
        //        <li class="page-item disabled">
        //            <a class="page-link" href="#" tabindex="-1">Previous</a>
        //        </li>
        //        <li class="page-item"><a class="page-link" href="#">1</a></li>
        //        <li class="page-item"><a class="page-link" href="#">2</a></li>
        //        <li class="page-item"><a class="page-link" href="#">3</a></li>
        //        <li class="page-item">
        //            <a class="page-link" href="#">Next</a>
        //        </li>
        //    </ul>
        //</nav>
    }
};

//<span class="prev">prev</span>
//    <ul>
//        <li>0</li>
//        <li>1</li>
//        <li class="active">2</li>
//        <li>3</li>
//        <li>4</li>
//    </ul>
//    <span class="next">next</span>


//$('.prev').on('click', function () {
//    var i = $(".active").index();
//    i--;
//    $(".active").removeClass('active');
//    $('li').eq(i).addClass('active');
//});

//$('.next').on('click', function () {
//    var i = $(".active").index();
//    i = i >= $('li').length - 1 ? 0 : i + 1;
//    $(".active").removeClass('active');
//    $('li').eq(i).addClass('active');
//});