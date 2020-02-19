import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class TicketHttpService {
    private baseAddress: string;

    private constructUrl(route: string, queryData?: any) : string {
        let url = this.baseAddress + route;

        if (queryData){
            url = url + this.createQueryString(queryData);
        }

        return url;
    }

    private createQueryString(queryData: any) : string {
        return Object.getOwnPropertyNames(queryData)
            .map(p => ({ 
                key: p,
                val: queryData[p]
             }))
            .filter(pair => pair.val !== null)
            .map(pair => `${pair.key}=${pair.val}`)
            .reduce((acc, curr) => {
                return `${acc}?${curr}`
            }, '');
    }

    constructor(private http: HttpClient) {
        this.baseAddress = 'https://localhost:44388/api/ticketing';
    }

    public post<TResult>(route: string, data: any) : Observable<TResult> {
        return this.http.post<TResult>(this.constructUrl(route), data);
    }

    public put<TResult>(route: string, data: any) : Observable<TResult> {
        return this.http.put<TResult>(this.constructUrl(route), data);
    }

    public get<TResult>(route: string, queryData?: any) : Observable<TResult> {
        if (queryData === null){
            return this.http.get<TResult>(this.constructUrl(route));
        }

        return this.http.get<TResult>(this.constructUrl(route, queryData));
    }

}