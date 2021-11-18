import { Component } from '@angular/core'

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'Web'

    name: string = 'Frederico'

    lista: Array<string> = [
        'Frederico',
        'Volkart',
        'Jacobi'
    ]
}
