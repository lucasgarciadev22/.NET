import React from 'react';

export const Header = () => {

    const headerStyle = {

        width: '100%',
        padding: '4%',
        backgroundColor: "lightblue",
        color: 'black',
        textAlign: 'center'
    }

    return(
        <div style={headerStyle}>
            <h1>React + NETCore</h1>
        </div>
    )
}