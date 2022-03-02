import React from 'react';
import { Routes, Route, Navigate, BrowserRouter } from 'react-router-dom';
import { SingleCard } from './layouts';
import { LoginForm, ResetPasswordForm, ChangePasswordForm, CreateAccountForm } from './components';

export default function UnauthenticatedContent() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path='/login' >
        <SingleCard title="Sign In">
          <LoginForm />
        </SingleCard>
      </Route>
      <Route path='/create-account' >
        <SingleCard title="Sign Up">
          <CreateAccountForm />
        </SingleCard>
      </Route>
      <Route path='/reset-password' >
        <SingleCard
          title="Reset Password"
          description="Please enter the email address that you used to register, and we will send you a link to reset your password via Email."
        >
          <ResetPasswordForm />
        </SingleCard>
      </Route>
      <Route path='/change-password/:recoveryCode' >
        <SingleCard title="Change Password">
          <ChangePasswordForm />
        </SingleCard>
      </Route>
      <Navigate to={'/login'} />
    </Routes>
    </BrowserRouter>
  );
}
