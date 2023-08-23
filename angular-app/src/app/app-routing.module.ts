import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

const routes: Routes = [

  {path: '', component:HomeComponent,title: 'home'},
  {path: 'home', component:HomeComponent,title: 'home'},
  {path: 'register', component:RegisterComponent,title: 'تسجيل كمستفيد'},
  {path: 'userprofile', component:UserProfileComponent,title: 'الملف الشخصى'}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
