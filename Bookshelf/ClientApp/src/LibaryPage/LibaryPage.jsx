import React from 'react';
import { bookService } from '@/_services';
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
                                    <th>Loan</th>

                                </tr>
                            </thead>
                            {books.map(book =>
                                <tbody key={book.id}>
                                    <tr>
                                        <td>{book.title}</td>
                                        <td>{book.author.name}</td>
                                        <td>{!book.loans && (<button type="button" className="btn btn-success">Loan</button> )}</td>
                                        <td>{book.loans && (<button type="button" className="btn btn-info">Return</button> )}</td>
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