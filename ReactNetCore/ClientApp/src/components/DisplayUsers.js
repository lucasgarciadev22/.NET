import React from 'react'

const DisplayUsers = ({numberOfUsers, getAllUsers}) => {

    return(
        <div style={{backgroundColor:'green'}} className="display-board">
            <h4 style={{color: 'white'}}>Created Users:</h4>
            <div className="number">
            {numberOfUsers}
            </div>
            <div className="btn">
                <button type="button" onClick={(e) => getAllUsers()} className="btn btn-warning">Get all created users</button>
            </div>
        </div>
    )
}

export default DisplayUsers;