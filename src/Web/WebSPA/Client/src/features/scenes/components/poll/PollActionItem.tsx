import { MenuItem } from '@material-ui/core';
import PollIcon from '@material-ui/icons/Poll';
import React from 'react';
import { useTranslation } from 'react-i18next';
import { useDispatch, useSelector } from 'react-redux';
import { setCreationDialogOpen } from 'src/features/poll/reducer';
import { ActionListItemProps } from 'src/features/scenes/types';
import { selectIsBreakoutRoomsOpen } from '../../../breakout-rooms/selectors';

export default function PollActionItem({ onClose }: ActionListItemProps) {
   const dispatch = useDispatch();
   const { t } = useTranslation();

   const handleOpen = () => {
      dispatch(setCreationDialogOpen(true));
      onClose();
   };

   const isOpen = useSelector(selectIsBreakoutRoomsOpen);

   return (
      <MenuItem id="scene-management-actions-poll" onClick={handleOpen} disabled={isOpen}>
         <PollIcon fontSize="small" style={{ marginRight: 16 }} />
         {t('conference.scenes.poll.label')}
      </MenuItem>
   );
}
