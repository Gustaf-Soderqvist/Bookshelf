import config from 'config';
import { handleResponse } from '@/_helpers';

export const bookService = {
    getBooks
};

function getBooks() {
    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' },

    };

    return fetch(`${config.apiUrl}/api/books`, requestOptions)
        .then(handleResponse)
        .then(books => {
            return books;
        });
}