import React, { Component } from 'react';
import DisplayUsers from './components/DisplayUsers/DisplayUsers';
import { Header } from './components/Header/Header';
import UserCreate from './components/UserCreate/UserCreate';
import { Users } from './components/Users/Users';
import { getAllUsers, createUser,deleteUser } from './services/UserService'
import './custom.css';

export default class App extends Component {

  state = {
    user: {},
    users: [],
    numberOfUsers: 0
  }

  createUser = () => {
    createUser(this.state.user)
      .then(response => {
        console.log(response);
        this.setState({ numberOfUsers: this.state.numberOfUsers + 1 })
      });
  }

  deleteUser = () => {
    deleteUser(this.state.user)
      .then(response => {
        console.log(response);
        this.setState({ numberOfUsers: this.state.numberOfUsers - 1 })
      });
  }

  getAllUsers = () => {
    getAllUsers()
      .then(users => {
        console.log(users)
        this.setState({ users: users, numberOfUsers: users.length })
      });
  }

  onChangeForm = (e) => {
    let user = this.state.user
    if (e.target.name === 'firstname') {
      user.firstName = e.target.value;
    } else if (e.target.name === 'lastname') {
      user.lastName = e.target.value;
    } else if (e.target.name === 'email') {
      user.email = e.target.value;
    }
    this.setState({ user })
  }

  render() {
    return (
      <div className='App'>
        <Header></Header>
        <div className='container mrgnbtm'>
          <div className='row'>
            <div className='col-md-8'>
              <UserCreate onChangeForm={this.onChangeForm}
                createUser={this.createUser}>
              </UserCreate>
            </div>
            <div className='col-md-4'>
              <DisplayUsers
              numberOfUsers={this.state.numberOfUsers}
              getAllUsers={this.getAllUsers}>
              </DisplayUsers>
            </div>
          </div>
          <div className='row mrgnbtm'>
            <Users users={this.state.users}>
            </Users>
          </div>
        </div>
      </div>
    );
  }
}

