import config from 'config';
import { handleResponse } from '@/_helpers';

export const loanService = {
    loanBook,
    returnBook
};

function loanBook(bookModel) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' },
        body: JSON.stringify(bookModel)

    };

    return fetch(`${config.apiUrl}/api/loans`, requestOptions)
        .then(handleResponse)
        .then(result => {
            return result;
        });
}
function returnBook(id) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' },
    };

    return fetch(`${config.apiUrl}/api/loans/${id}`, requestOptions)
        .then(handleResponse)
        .then(result => {
            return result;
        });
}