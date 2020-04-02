import React from 'react';
import { bookService, loanService } from '@/_services';
class LibaryPage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            books: null
        };

    }

    componentDidMount() {

        bookService.getBooks().then(books => this.setState({ books }));
    }

    getBooks() {
        bookService.getBooks().then(books => this.setState({ books }));
    }

    loan(event, book) {
        loanService.loanBook(book).then(res =>
            alert("Congrats! The book is on loan. Due date " + res)
        ).then(() => bookService.getBooks().then(books => this.setState({ books })));
    }

    return(event, bookId) {
        loanService.returnBook(bookId).then(result =>
            alert("Thank you for the return, dear human reader")
        ).then(() => bookService.getBooks().then(books => this.setState({ books })));
    }

    render() {
        const { books } = this.state;
        return (
            <div>
                {books &&
                    <div className="container">
                        <h3>Books</h3>
                        <table className="table table-borderless">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Author</th>
                                    <th>Genre</th>
                                    <th>Loan</th>

                                </tr>
                            </thead>
                            {books.map(book =>
                                <tbody key={book.id}>
                                    <tr>
                                        <td>{book.title}</td>
                                        <td>{book.author.name}</td>
                                        <td>{book.genre}</td>
                                        <td>
                                            {!book.loaned && (<button type="button"
                                                className="btn btn-success"
                                                onClick={(e) => {
                                                    this.loan(e, book)
                                                }}>
                                                Loan</button>)}

                                            {book.loaned && (<button type="button"
                                                className="btn btn-info"
                                                onClick={(e) => {
                                                    this.return(e, book.id)
                                                }}>
                                                Return</button>)}</td>
                                    </tr>
                                </tbody>
                            )}
                        </table>
                    </div>
                }
            </div>
        );
    }
}

export { LibaryPage };